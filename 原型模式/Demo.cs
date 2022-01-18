using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace 原型模式
{

    public class Demo
    {
        public Dictionary<string, SearchWord> currentKeywords = new Dictionary<string, SearchWord>();
        public int lastindex = -1;
        public void init()
        {
           Dictionary<string, SearchWord> newKeywords = new Dictionary<string, SearchWord>();

            // 从数据库中取出所有的数据，放入到newKeywords中
            List<SearchWord> toBeUpdatedSearchWords = getSearchWords();
            int maxindex = lastindex;
            foreach (SearchWord searchWord in toBeUpdatedSearchWords)
            {
                newKeywords.Add(searchWord.name, searchWord);
            }
            currentKeywords = newKeywords;
        }
        public void refresh()
        {
            //Dictionary<string, SearchWord> newKeywords = new Dictionary<string, SearchWord>();
            Dictionary<string, SearchWord> newKeywords = currentKeywords;

            // 从数据库中取出所有的数据，放入到newKeywords中
            List<SearchWord> toBeUpdatedSearchWords = getSearchWords();
            int maxindex = lastindex;
            foreach (SearchWord searchWord in toBeUpdatedSearchWords)
            {
                //原型模式的关键点就是拷贝这里，赋值新的值
                searchWord.status = "new";
                if (searchWord.getLastIndex() > maxindex)
                {
                    maxindex = searchWord.getLastIndex();
                }
                if (newKeywords.ContainsKey(searchWord.name))
                {
                    newKeywords.Remove(searchWord.name);
                }
                newKeywords.Add(searchWord.name, searchWord);
            }
            lastindex = maxindex;
            currentKeywords = newKeywords;
        }

        private List<SearchWord> getSearchWords()
        {
            List<SearchWord> result = new List<SearchWord>();
            for (int i = 0; i < 50; i++)
            {
                result.Add(new SearchWord()
                {
                    index = i,
                    name = $"这是第{i}个数",
                    createTime = DateTime.Now
                });
            }
            // TODO: 从数据库中取出所有的数据
            return result;
        }
    }

    public class SearchWord
    {
        public DateTime createTime;
        public int index { get; set; }
        public string name { get; set; }
        public string status { get; set; } = "old";
        public long timestamp
        {
            get
            {
                TimeSpan ts = this.createTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return Convert.ToInt64(ts.TotalSeconds);
            }

        }

        internal int getLastIndex()
        {
            return 20;
        }

        internal long GetTimestamp()
        {
            return this.timestamp;
        }
    }
}
