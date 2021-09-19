using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalForensics.ElasticSearch.ElasticSearchModel;
using Nest;

namespace DigitalForensics.ElasticSearch.ElasticSearchFunctions
{
    public class ElasticSearchQueries
    {

        public static List<string> getAllDistinctExtensions(string indexName)
        {
            List<string> retList = new List<string>();

           

            var respone = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
            .Index(indexName)
            .Size(0)
            .Aggregations(aggs => aggs.Terms("number_of_extensions",t=>t.Field(p=>p.Extension).Size(500))
            ));
            
            foreach (var hit in respone.Aggregations.Terms("number_of_extensions").Buckets)
            {
                retList.Add(hit.Key);
            }

            return retList;
        }

        public static List<DocumentAttributes> getDocumentsByNameWithSpace(string indexName,List<string> names)
        {
            List<DocumentAttributes> retList = new List<DocumentAttributes>();

            var response = ConnectionToES.EsClient().Search<DocumentAttributes>(s =>s
                .Index(indexName)
                .Size(10000)
                .Query(q=> q.Terms(p=>p.Field(f=>f.Name).Terms(names)))
            );

            foreach (var res in response.Hits)
            {
                retList.Add(new DocumentAttributes
                {
                    Name = res.Source.Name,
                    CacheDate = res.Source.CacheDate,
                    CreationTime = res.Source.CreationTime,
                    LastAccessTime = res.Source.LastAccessTime,
                    LastModificationTime = res.Source.LastModificationTime,
                    Extension = res.Source.Extension,
                    NumberOfFiles = res.Source.NumberOfFiles,
                    Size = res.Source.Size
                });
            }

            return retList;
        }

        public static List<DocumentAttributes> getDocumentsByName(string indexName,string name)
        {
            List<DocumentAttributes> retList = new List<DocumentAttributes>();

            var response = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                .Index(indexName)
                .Size(10000)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Name)
                        .Query(name)))
            );

            foreach(var res in response.Hits)
            {
                retList.Add(new DocumentAttributes
                {
                    Name = res.Source.Name,
                    CacheDate = res.Source.CacheDate,
                    CreationTime = res.Source.CreationTime,
                    LastAccessTime = res.Source.LastAccessTime,
                    LastModificationTime = res.Source.LastModificationTime,
                    Extension = res.Source.Extension,
                    NumberOfFiles = res.Source.NumberOfFiles,
                    Size = res.Source.Size
                });
            }

            return retList;
        }

        public static string getIDOfDucument(string indexName,string name, string extension, int numberOfFiles,long size)
        {
            List<DisplayCacheModelES> displayCach = new List<DisplayCacheModelES>();
            var response = ConnectionToES.EsClient().Search<DisplayCacheModelES>(s => s
                .Index(indexName)
                .Size(1)
                .Query(q=>q
                    .Match(m => m
                        .Field(f => f.Name)
                        .Query(name))
                    && q
                        .Match(m=>m
                            .Field(f=>f.Extension)
                            .Query(extension))
                    && q
                    .Term(f=>f.NumberOfFiles,numberOfFiles)
                    && q 
                        .Term(f=>f.Size,size)
              )
            );

            foreach(var r in response.Hits)
            {
                displayCach.Add(new DisplayCacheModelES
                {
                    Id = r.Id,
                    Name = r.Source.Name,
                    CacheDate = r.Source.CacheDate,
                    CreationTime = r.Source.CreationTime,
                    Extension = r.Source.Extension,
                    LastAccessTime = r.Source.LastAccessTime,
                    LastModificationTime = r.Source.LastModificationTime,
                    NumberOfFiles = r.Source.NumberOfFiles,
                    Size = r.Source.Size
                });
            }

            return displayCach.First().Id;
            
        }

        public static List<DocumentAttributes> previusData(List<string> listOfIndexes, string name, string extension, int numberOfFiles, long size)
        {
            List<DocumentAttributes> retList = new List<DocumentAttributes>();

            var response = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                .AllIndices()
                .Query(q => q
                                 .Match(m => m
                                     .Field(f => f.Name)
                                     .Query(name))
                                 && q
                                     .Match(m => m
                                         .Field(f => f.Extension)
                                         .Query(extension))
                                 && q
                                 .Term(f => f.NumberOfFiles, numberOfFiles)
                                 && q
                                     .Term(f => f.Size, size)));

            foreach (var res in response.Hits)
            {
                retList.Add(new DocumentAttributes
                {
                    Name = res.Source.Name,
                    CacheDate = res.Source.CacheDate,
                    CreationTime = res.Source.CreationTime,
                    LastAccessTime = res.Source.LastAccessTime,
                    LastModificationTime = res.Source.LastModificationTime,
                    Extension = res.Source.Extension,
                    NumberOfFiles = res.Source.NumberOfFiles,
                    Size = res.Source.Size
                });
            }

            return retList;
        }

        public static List<DocumentAttributes> getDocumentIDByName(string indexName, string id)
        {
            List<DocumentAttributes> retList = new List<DocumentAttributes>();

            var response = ConnectionToES.EsClient().Search<DisplayCacheModelES>(s => s
                .Index(indexName)
                .Size(1)
                .Query(q => q.Term(t => t.Field("_id").Value(id)))
            );

            foreach (var res in response.Hits)
            {
                retList.Add(new DocumentAttributes
                {
                    Name = res.Source.Name,
                    CacheDate = res.Source.CacheDate,
                    CreationTime = res.Source.CreationTime,
                    LastAccessTime = res.Source.LastAccessTime,
                    LastModificationTime = res.Source.LastModificationTime,
                    Extension = res.Source.Extension,
                    NumberOfFiles = res.Source.NumberOfFiles,
                    Size = res.Source.Size
                });
            }

            return retList;
        }

        public static List<DocumentAttributes> getAllDocuments(string indexName)
        {
            List<DocumentAttributes> retList = new List<DocumentAttributes>();

            var response = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                .Index(indexName)
                .Size(10000)
                .Query(q=>q.MatchAll())
                .Scroll("5m")
            );

            foreach(var res in response.Hits)
            {
                retList.Add(new DocumentAttributes { 
                    Name = res.Source.Name,
                    Extension = res.Source.Extension,
                    Size = res.Source.Size,
                    NumberOfFiles = res.Source.NumberOfFiles,
                    CreationTime = res.Source.CreationTime,
                    LastAccessTime = res.Source.LastAccessTime,
                    LastModificationTime = res.Source.LastModificationTime,
                    CacheDate = res.Source.CacheDate
                });
            }

            return retList;
        }

        public static List<DocumentAttributes> getFilesByPeriodOfTime(string indexName,string FieldName, List<string> types, DateTime from, DateTime? to = null)
        {
            List<DocumentAttributes> retList = new List<DocumentAttributes>();

            if (types.Any(x => x == "All"))
            {
                //If any => any extension
                if (to == null)
                {
                    if(from==null)
                    {
                        //For 30 days
                        DateTime dateNow = DateTime.Now;
                        DateTime past30Days = dateNow.AddDays(-30);

                        if (FieldName.Equals("Name"))
                        {
                            var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f=>f.Name)
                                    .GreaterThanOrEquals(past30Days)
                                    .LessThan(dateNow)
                                )
                            )
                        );

                            foreach (var r in res.Hits)
                            {
                                retList.Add(new DocumentAttributes
                                {
                                    Name = r.Source.Name,
                                    Extension = r.Source.Extension,
                                    Size = r.Source.Size,
                                    NumberOfFiles = r.Source.NumberOfFiles,
                                    CreationTime = r.Source.CreationTime,
                                    LastAccessTime = r.Source.LastAccessTime,
                                    LastModificationTime = r.Source.LastModificationTime,
                                    CacheDate = r.Source.CacheDate
                                });
                            }
                        }
                        else
                        {
                            if(FieldName.Equals("CreationTime"))
                            {
                                var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                    .Index(indexName)
                                    .Size(10000)
                                    .Query(q => q
                                        .DateRange(r => r
                                            .Field(f => f.CreationTime)
                                            .GreaterThanOrEquals(past30Days)
                                            .LessThan(dateNow)
                                        )
                                    )
                                );

                                foreach (var r in res.Hits)
                                {
                                    retList.Add(new DocumentAttributes
                                    {
                                        Name = r.Source.Name,
                                        Extension = r.Source.Extension,
                                        Size = r.Source.Size,
                                        NumberOfFiles = r.Source.NumberOfFiles,
                                        CreationTime = r.Source.CreationTime,
                                        LastAccessTime = r.Source.LastAccessTime,
                                        LastModificationTime = r.Source.LastModificationTime,
                                        CacheDate = r.Source.CacheDate
                                    });
                                }
                            }
                            else
                            {
                                if(FieldName.Equals("LastAccessTime"))
                                {
                                    var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                        .Index(indexName)
                                        .Size(10000)
                                        .Query(q => q
                                            .DateRange(r => r
                                                .Field(f => f.LastAccessTime)
                                                .GreaterThanOrEquals(past30Days)
                                                .LessThan(dateNow)
                                            )
                                        )
                                    );

                                    foreach (var r in res.Hits)
                                    {
                                        retList.Add(new DocumentAttributes
                                        {
                                            Name = r.Source.Name,
                                            Extension = r.Source.Extension,
                                            Size = r.Source.Size,
                                            NumberOfFiles = r.Source.NumberOfFiles,
                                            CreationTime = r.Source.CreationTime,
                                            LastAccessTime = r.Source.LastAccessTime,
                                            LastModificationTime = r.Source.LastModificationTime,
                                            CacheDate = r.Source.CacheDate
                                        });
                                    }
                                }
                                else
                                {
                                    var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                            .Index(indexName)
                                            .Size(10000)
                                            .Query(q => q
                                                .DateRange(r => r
                                                    .Field(f => f.LastModificationTime)
                                                    .GreaterThanOrEquals(past30Days)
                                                    .LessThan(dateNow)
                                                )
                                            )
                                        );

                                    foreach (var r in res.Hits)
                                    {
                                        retList.Add(new DocumentAttributes
                                        {
                                            Name = r.Source.Name,
                                            Extension = r.Source.Extension,
                                            Size = r.Source.Size,
                                            NumberOfFiles = r.Source.NumberOfFiles,
                                            CreationTime = r.Source.CreationTime,
                                            LastAccessTime = r.Source.LastAccessTime,
                                            LastModificationTime = r.Source.LastModificationTime,
                                            CacheDate = r.Source.CacheDate
                                        });
                                    }
                                }
                            }
                        }

                        
                        
                    }
                    else
                    {
                        //For day ->have parametar from
                        DateTime pastDay = from.AddDays(-1);

                        if (FieldName.Equals("Name"))
                        {
                            var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                    .Index(indexName)
                                    .Size(10000)
                                    .Query(q => q
                                        .DateRange(r => r
                                            .Field(f=>f.Name)
                                            .GreaterThanOrEquals(pastDay)
                                            .LessThan(from)
                                        )
                                    )
                                );

                            foreach (var r in res.Hits)
                            {
                                retList.Add(new DocumentAttributes
                                {
                                    Name = r.Source.Name,
                                    Extension = r.Source.Extension,
                                    Size = r.Source.Size,
                                    NumberOfFiles = r.Source.NumberOfFiles,
                                    CreationTime = r.Source.CreationTime,
                                    LastAccessTime = r.Source.LastAccessTime,
                                    LastModificationTime = r.Source.LastModificationTime,
                                    CacheDate = r.Source.CacheDate
                                });
                            }
                        }
                        else
                        {
                            if (FieldName.Equals("CreationTime"))
                            {
                                var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                   .Index(indexName)
                                   .Size(10000)
                                   .Query(q => q
                                       .DateRange(r => r
                                           .Field(f => f.CreationTime)
                                           .GreaterThanOrEquals(pastDay)
                                           .LessThan(from)
                                       )
                                   )
                               );

                                foreach (var r in res.Hits)
                                {
                                    retList.Add(new DocumentAttributes
                                    {
                                        Name = r.Source.Name,
                                        Extension = r.Source.Extension,
                                        Size = r.Source.Size,
                                        NumberOfFiles = r.Source.NumberOfFiles,
                                        CreationTime = r.Source.CreationTime,
                                        LastAccessTime = r.Source.LastAccessTime,
                                        LastModificationTime = r.Source.LastModificationTime,
                                        CacheDate = r.Source.CacheDate
                                    });
                                }
                            }
                            else
                            {
                                if (FieldName.Equals("LastAccessTime"))
                                {
                                    var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                   .Index(indexName)
                                   .Size(10000)
                                   .Query(q => q
                                       .DateRange(r => r
                                           .Field(f => f.LastAccessTime)
                                           .GreaterThanOrEquals(pastDay)
                                           .LessThan(from)
                                       )
                                   )
                               );

                                    foreach (var r in res.Hits)
                                    {
                                        retList.Add(new DocumentAttributes
                                        {
                                            Name = r.Source.Name,
                                            Extension = r.Source.Extension,
                                            Size = r.Source.Size,
                                            NumberOfFiles = r.Source.NumberOfFiles,
                                            CreationTime = r.Source.CreationTime,
                                            LastAccessTime = r.Source.LastAccessTime,
                                            LastModificationTime = r.Source.LastModificationTime,
                                            CacheDate = r.Source.CacheDate
                                        });
                                    }
                                }
                                else
                                {
                                    var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                   .Index(indexName)
                                   .Size(10000)
                                   .Query(q => q
                                       .DateRange(r => r
                                           .Field(f => f.LastModificationTime)
                                           .GreaterThanOrEquals(pastDay)
                                           .LessThan(from)
                                       )
                                   )
                               );

                                    foreach (var r in res.Hits)
                                    {
                                        retList.Add(new DocumentAttributes
                                        {
                                            Name = r.Source.Name,
                                            Extension = r.Source.Extension,
                                            Size = r.Source.Size,
                                            NumberOfFiles = r.Source.NumberOfFiles,
                                            CreationTime = r.Source.CreationTime,
                                            LastAccessTime = r.Source.LastAccessTime,
                                            LastModificationTime = r.Source.LastModificationTime,
                                            CacheDate = r.Source.CacheDate
                                        });
                                    }
                                }
                            }
                        }
                        
                        

                    }
                }
                else
                {
                    //For period
                    
                    if(FieldName.Equals("Name"))
                    {
                        var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f=>f.Name)
                                    .GreaterThanOrEquals(from)
                                    .LessThan(to)
                                )
                            )
                        );
                        foreach (var r in res.Hits)
                        {
                            retList.Add(new DocumentAttributes
                            {
                                Name = r.Source.Name,
                                Extension = r.Source.Extension,
                                Size = r.Source.Size,
                                NumberOfFiles = r.Source.NumberOfFiles,
                                CreationTime = r.Source.CreationTime,
                                LastAccessTime = r.Source.LastAccessTime,
                                LastModificationTime = r.Source.LastModificationTime,
                                CacheDate = r.Source.CacheDate
                            });
                        }
                    }
                    else
                    {
                        if(FieldName.Equals("CreationTime"))
                        {
                            var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f => f.CreationTime)
                                    .GreaterThanOrEquals(from)
                                    .LessThan(to)
                                )
                            )
                        );
                            foreach (var r in res.Hits)
                            {
                                retList.Add(new DocumentAttributes
                                {
                                    Name = r.Source.Name,
                                    Extension = r.Source.Extension,
                                    Size = r.Source.Size,
                                    NumberOfFiles = r.Source.NumberOfFiles,
                                    CreationTime = r.Source.CreationTime,
                                    LastAccessTime = r.Source.LastAccessTime,
                                    LastModificationTime = r.Source.LastModificationTime,
                                    CacheDate = r.Source.CacheDate
                                });
                            }
                        }
                        else
                        {
                            if(FieldName.Equals("LastAccessTime"))
                            {
                                var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f => f.LastAccessTime)
                                    .GreaterThanOrEquals(from)
                                    .LessThan(to)
                                )
                            )
                        );
                                foreach (var r in res.Hits)
                                {
                                    retList.Add(new DocumentAttributes
                                    {
                                        Name = r.Source.Name,
                                        Extension = r.Source.Extension,
                                        Size = r.Source.Size,
                                        NumberOfFiles = r.Source.NumberOfFiles,
                                        CreationTime = r.Source.CreationTime,
                                        LastAccessTime = r.Source.LastAccessTime,
                                        LastModificationTime = r.Source.LastModificationTime,
                                        CacheDate = r.Source.CacheDate
                                    });
                                }
                            }
                            else
                            {
                                var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f => f.LastModificationTime)
                                    .GreaterThanOrEquals(from)
                                    .LessThan(to)
                                )
                            )
                        );
                                foreach (var r in res.Hits)
                                {
                                    retList.Add(new DocumentAttributes
                                    {
                                        Name = r.Source.Name,
                                        Extension = r.Source.Extension,
                                        Size = r.Source.Size,
                                        NumberOfFiles = r.Source.NumberOfFiles,
                                        CreationTime = r.Source.CreationTime,
                                        LastAccessTime = r.Source.LastAccessTime,
                                        LastModificationTime = r.Source.LastModificationTime,
                                        CacheDate = r.Source.CacheDate
                                    });
                                }
                            }
                        }
                    }
                    
                }
            }
            else
            {
                //List of extensions
                if (to == null)
                {
                    if(from==null)
                    {
                        //For 30days
                        DateTime dateNow = DateTime.Now;
                        DateTime past30Days = dateNow.AddDays(-30);

                        if (FieldName.Equals("Name"))
                        {
                            var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                .Index(indexName)
                                .Size(10000)
                                .Query(q => q
                                    .DateRange(r => r
                                        .Field(f=>f.Name)
                                        .GreaterThanOrEquals(past30Days)
                                        .LessThan(dateNow)
                                    ) && q
                                    .Terms(p => p
                                        .Field(f=>f.Extension)
                                        .Terms(types)
                                ))
                            );

                            foreach (var r in res.Hits)
                            {
                                retList.Add(new DocumentAttributes
                                {
                                    Name = r.Source.Name,
                                    Extension = r.Source.Extension,
                                    Size = r.Source.Size,
                                    NumberOfFiles = r.Source.NumberOfFiles,
                                    CreationTime = r.Source.CreationTime,
                                    LastAccessTime = r.Source.LastAccessTime,
                                    LastModificationTime = r.Source.LastModificationTime,
                                    CacheDate = r.Source.CacheDate
                                });
                            }
                        }
                        else
                        {
                            if (FieldName.Equals("CreationTime"))
                            {
                                var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                .Index(indexName)
                                .Size(10000)
                                .Query(q => q
                                    .DateRange(r => r
                                        .Field(f => f.CreationTime)
                                        .GreaterThanOrEquals(past30Days)
                                        .LessThan(dateNow)
                                    ) && q
                                    .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                                )
                            );

                                foreach (var r in res.Hits)
                                {
                                    retList.Add(new DocumentAttributes
                                    {
                                        Name = r.Source.Name,
                                        Extension = r.Source.Extension,
                                        Size = r.Source.Size,
                                        NumberOfFiles = r.Source.NumberOfFiles,
                                        CreationTime = r.Source.CreationTime,
                                        LastAccessTime = r.Source.LastAccessTime,
                                        LastModificationTime = r.Source.LastModificationTime,
                                        CacheDate = r.Source.CacheDate
                                    });
                                }
                            }
                            else
                            {
                                if (FieldName.Equals("LastAccessTime"))
                                {
                                    var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                            .Index(indexName)
                                            .Size(10000)
                                            .Query(q => q
                                                .DateRange(r => r
                                                    .Field(f => f.LastAccessTime)
                                                    .GreaterThanOrEquals(past30Days)
                                                    .LessThan(dateNow)
                                                ) && q
                                                .Terms(p => p
                                                        .Field(f => f.Extension)
                                                        .Terms(types)
                                                )
                                            )
                                        );

                                    foreach (var r in res.Hits)
                                    {
                                        retList.Add(new DocumentAttributes
                                        {
                                            Name = r.Source.Name,
                                            Extension = r.Source.Extension,
                                            Size = r.Source.Size,
                                            NumberOfFiles = r.Source.NumberOfFiles,
                                            CreationTime = r.Source.CreationTime,
                                            LastAccessTime = r.Source.LastAccessTime,
                                            LastModificationTime = r.Source.LastModificationTime,
                                            CacheDate = r.Source.CacheDate
                                        });
                                    }
                                }
                                else
                                {
                                    var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                        .Index(indexName)
                                        .Size(10000)
                                        .Query(q => q
                                            .DateRange(r => r
                                                .Field(f => f.LastModificationTime)
                                                .GreaterThanOrEquals(past30Days)
                                                .LessThan(dateNow)
                                            ) && q
                                            .Terms(p => p
                                                    .Field(f => f.Extension)
                                                    .Terms(types)
                                            )
                                        )
                                    );

                                    foreach (var r in res.Hits)
                                    {
                                        retList.Add(new DocumentAttributes
                                        {
                                            Name = r.Source.Name,
                                            Extension = r.Source.Extension,
                                            Size = r.Source.Size,
                                            NumberOfFiles = r.Source.NumberOfFiles,
                                            CreationTime = r.Source.CreationTime,
                                            LastAccessTime = r.Source.LastAccessTime,
                                            LastModificationTime = r.Source.LastModificationTime,
                                            CacheDate = r.Source.CacheDate
                                        });
                                    }
                                }
                            }
                        }
                        
                        
                    }
                    else
                    {
                        //For day
                        DateTime pastDay = from.AddDays(-1);
                        if (FieldName.Equals("Name"))
                        {
                            var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                .Index(indexName)
                                .Size(10000)
                                .Query(q => q
                                    .DateRange(r => r
                                        .Field(f=>f.Name)
                                        .GreaterThanOrEquals(pastDay)
                                        .LessThan(from)
                                    ) && q
                                    .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                                )
                            );

                            foreach (var r in res.Hits)
                            {
                                retList.Add(new DocumentAttributes
                                {
                                    Name = r.Source.Name,
                                    Extension = r.Source.Extension,
                                    Size = r.Source.Size,
                                    NumberOfFiles = r.Source.NumberOfFiles,
                                    CreationTime = r.Source.CreationTime,
                                    LastAccessTime = r.Source.LastAccessTime,
                                    LastModificationTime = r.Source.LastModificationTime,
                                    CacheDate = r.Source.CacheDate
                                });
                            }
                        }
                        else
                        {
                            if (FieldName.Equals("CreationTime"))
                            {
                                var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                .Index(indexName)
                                .Size(10000)
                                .Query(q => q
                                    .DateRange(r => r
                                        .Field(f => f.CreationTime)
                                        .GreaterThanOrEquals(pastDay)
                                        .LessThan(from)
                                    ) && q
                                    .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                                )
                            );

                                foreach (var r in res.Hits)
                                {
                                    retList.Add(new DocumentAttributes
                                    {
                                        Name = r.Source.Name,
                                        Extension = r.Source.Extension,
                                        Size = r.Source.Size,
                                        NumberOfFiles = r.Source.NumberOfFiles,
                                        CreationTime = r.Source.CreationTime,
                                        LastAccessTime = r.Source.LastAccessTime,
                                        LastModificationTime = r.Source.LastModificationTime,
                                        CacheDate = r.Source.CacheDate
                                    });
                                }
                            }
                            else
                            {
                                if (FieldName.Equals("LastAccessTime"))
                                {
                                    var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                .Index(indexName)
                                .Size(10000)
                                .Query(q => q
                                    .DateRange(r => r
                                        .Field(f => f.LastAccessTime)
                                        .GreaterThanOrEquals(pastDay)
                                        .LessThan(from)
                                    ) && q
                                    .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                                )
                            );

                                    foreach (var r in res.Hits)
                                    {
                                        retList.Add(new DocumentAttributes
                                        {
                                            Name = r.Source.Name,
                                            Extension = r.Source.Extension,
                                            Size = r.Source.Size,
                                            NumberOfFiles = r.Source.NumberOfFiles,
                                            CreationTime = r.Source.CreationTime,
                                            LastAccessTime = r.Source.LastAccessTime,
                                            LastModificationTime = r.Source.LastModificationTime,
                                            CacheDate = r.Source.CacheDate
                                        });
                                    }
                                }
                                else
                                {
                                    var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                                .Index(indexName)
                                .Size(10000)
                                .Query(q => q
                                    .DateRange(r => r
                                        .Field(f => f.LastModificationTime)
                                        .GreaterThanOrEquals(pastDay)
                                        .LessThan(from)
                                    ) && q
                                    .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                                )
                            );

                                    foreach (var r in res.Hits)
                                    {
                                        retList.Add(new DocumentAttributes
                                        {
                                            Name = r.Source.Name,
                                            Extension = r.Source.Extension,
                                            Size = r.Source.Size,
                                            NumberOfFiles = r.Source.NumberOfFiles,
                                            CreationTime = r.Source.CreationTime,
                                            LastAccessTime = r.Source.LastAccessTime,
                                            LastModificationTime = r.Source.LastModificationTime,
                                            CacheDate = r.Source.CacheDate
                                        });
                                    }
                                }
                            }
                        }
                        
                        
                    }
                }
                else
                {
                    //For period
                    if (FieldName.Equals("Name"))
                    {
                        var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f=>f.Name)
                                    .GreaterThanOrEquals(from)
                                    .LessThan(to)
                                ) && q
                                .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                            )
                        );

                        foreach (var r in res.Hits)
                        {
                            retList.Add(new DocumentAttributes
                            {
                                Name = r.Source.Name,
                                Extension = r.Source.Extension,
                                Size = r.Source.Size,
                                NumberOfFiles = r.Source.NumberOfFiles,
                                CreationTime = r.Source.CreationTime,
                                LastAccessTime = r.Source.LastAccessTime,
                                LastModificationTime = r.Source.LastModificationTime,
                                CacheDate = r.Source.CacheDate
                            });
                        }
                    }
                    else
                    {
                        if (FieldName.Equals("CreationTime"))
                        {
                            var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f => f.CreationTime)
                                    .GreaterThanOrEquals(from)
                                    .LessThan(to)
                                ) && q
                                .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                            )
                        );

                            foreach (var r in res.Hits)
                            {
                                retList.Add(new DocumentAttributes
                                {
                                    Name = r.Source.Name,
                                    Extension = r.Source.Extension,
                                    Size = r.Source.Size,
                                    NumberOfFiles = r.Source.NumberOfFiles,
                                    CreationTime = r.Source.CreationTime,
                                    LastAccessTime = r.Source.LastAccessTime,
                                    LastModificationTime = r.Source.LastModificationTime,
                                    CacheDate = r.Source.CacheDate
                                });
                            }
                        }
                        else
                        {
                            if (FieldName.Equals("LastAccessTime"))
                            {
                                var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f => f.LastAccessTime)
                                    .GreaterThanOrEquals(from)
                                    .LessThan(to)
                                ) && q
                                .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                            )
                        );

                                foreach (var r in res.Hits)
                                {
                                    retList.Add(new DocumentAttributes
                                    {
                                        Name = r.Source.Name,
                                        Extension = r.Source.Extension,
                                        Size = r.Source.Size,
                                        NumberOfFiles = r.Source.NumberOfFiles,
                                        CreationTime = r.Source.CreationTime,
                                        LastAccessTime = r.Source.LastAccessTime,
                                        LastModificationTime = r.Source.LastModificationTime,
                                        CacheDate = r.Source.CacheDate
                                    });
                                }
                            }
                            else
                            {
                                var res = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                            .Index(indexName)
                            .Size(10000)
                            .Query(q => q
                                .DateRange(r => r
                                    .Field(f => f.LastModificationTime)
                                    .GreaterThanOrEquals(from)
                                    .LessThan(to)
                                ) && q
                                .Terms(p => p
                                        .Field(f => f.Extension)
                                        .Terms(types)
                                )
                            )
                        );

                                foreach (var r in res.Hits)
                                {
                                    retList.Add(new DocumentAttributes
                                    {
                                        Name = r.Source.Name,
                                        Extension = r.Source.Extension,
                                        Size = r.Source.Size,
                                        NumberOfFiles = r.Source.NumberOfFiles,
                                        CreationTime = r.Source.CreationTime,
                                        LastAccessTime = r.Source.LastAccessTime,
                                        LastModificationTime = r.Source.LastModificationTime,
                                        CacheDate = r.Source.CacheDate
                                    });
                                }
                            }
                        }
                    }

                    
                }
            }

            return retList;
        }
    }
}
