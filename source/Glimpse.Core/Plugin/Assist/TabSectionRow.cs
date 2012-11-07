using System;
using System.Collections.Generic;
using System.Linq;

namespace Glimpse.Core.Plugin.Assist
{
    public class TabSectionRow : ITabBuild
    {
        private readonly List<TabColumn> columns = new List<TabColumn>();

        public IEnumerable<TabColumn> Columns
        {
            get { return columns; }
        }

        public TabSectionRow Column(object columnData)
        { 
            var column = new TabColumn(columnData);
            columns.Add(column);
            
            return this;
        }

        public object Build()
        {
            return columns.Select(x => x.Build());
        }
    }
}