using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Generic
{
    public class PagedList<T> : List<T>
    {

        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// 总数据条数
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; private set; }

        public PagedList(List<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            this.AddRange(source.Skip((PageIndex-1) * PageSize).Take(PageSize));
        }
        /// <summary>
        /// 是否包含上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex  < TotalPages);
            }
        }
    }
}