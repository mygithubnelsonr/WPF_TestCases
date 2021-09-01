using System.Collections.Generic;

namespace Entity
{
    public class QueryList : List<Query>
    {
        public QueryList()
        {

        }

        public QueryList Load()
        {
            QueryList queries = new QueryList();

            queries.Add(new Query() { ID = 4, Name = "Wtra_001", Row = 81 });
            queries.Add(new Query() { ID = 8, Name = "Ntra_001", Row = 33 });
            queries.Add(new Query() { ID = 0, Name = "Qtra_001", Row = 12 });
            queries.Add(new Query() { ID = 2, Name = "Btra_002", Row = 28 });
            queries.Add(new Query() { ID = 6, Name = "Xtra_003", Row = 15 });
            queries.Add(new Query() { ID = 5, Name = "Etra_004", Row = 56 });
            queries.Add(new Query() { ID = 10, Name = "Stra_005", Row = 41 });
            queries.Add(new Query() { ID = 7, Name = "Atra_006", Row = 97 });
            queries.Add(new Query() { ID = 9, Name = "Mtra_007", Row = 66 });
            queries.Add(new Query() { ID = 1, Name = "Ktra_008", Row = 38 });

            return queries;
        }
    }
}

