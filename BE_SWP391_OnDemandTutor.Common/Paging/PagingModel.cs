using System;
namespace BE_SWP391_OnDemandTutor.Common.Paging
{

    public class PagingModel<T> : PagingSizeModel
    {
        public T Filter { get; set; }
        public List<SortItems> Sorts { get; set; }
    }

    public class PagingSizeModel
    {
        public required int Page { get; set; } = 1;

        public required int Limit { get; set; } = 100;
    }


    public class SortItems
    {
        public string Column { get; set; }
        public bool IsDesc { get; set; }
    }
}

