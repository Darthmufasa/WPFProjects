using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> collectionToAdd)
        {
            if (collectionToAdd != null)
            {
                foreach (var i in collectionToAdd)
                {
                    collection.Add(i);
                }
            }
        }
    }
}
