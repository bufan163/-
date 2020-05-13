using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace 迭代器模式
{

    public class ArrayIterator<T> 
    {
        private int cursor;
        private List<T> arrayList;

        public ArrayIterator(List<T> arrayList)
        {
            this.cursor = 0;
            this.arrayList = arrayList;
        }
        public bool hasNext()
        {
            return cursor != arrayList.Count; //注意这里，cursor在指向最后一个元素的时候，hasNext()仍旧返回true。
        }
        public void next()
        {
            cursor++;
        }
        public T currentItem()
        {
            if (cursor >= arrayList.Count)
            {
                throw new ArgumentNullException();
            }
            return arrayList[cursor];
        }
    }
}
