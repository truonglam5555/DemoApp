using System;
using System.Collections.Generic;
using SQLite;
using Vitaorga.Models.Card;

namespace Vitaorga.Common.Bussiness
{
    public class DataBussiness
    {
        private readonly LocalDB localDB;
        public DataBussiness()
        {
            localDB = LocalDB.Instance;
            CreatTables();
        }

        public void CreatTables()
        {
            localDB.Database.CreateTable<MCard>();
        }

        public Object GetLastRow<T>()
        {
            if (localDB.TableExist(typeof(T).Name))
            {
                try
                {
                    string query = string.Format("SELECT * FROM '{0}' ORDER BY ID DESC LIMIT 1;", typeof(T).Name);
                    SQLiteCommand cmd = localDB.Database.CreateCommand(query);
                    var item = localDB.Database.Query<Object>(query);
                    if (item.Count > 0)
                    {
                        return item[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
            return default(T);
        }

        public List<MCard> GetAllRowCard()
        {
            if (localDB.TableExist(typeof(MCard).Name))
            {
                try
                {
                    string query = string.Format("SELECT * FROM '{0}' ;", typeof(MCard).Name);
                    SQLiteCommand cmd = localDB.Database.CreateCommand(query);
                    var item = localDB.Database.Query<MCard>(query);
                    if (item.Count > 0)
                    {
                        return item;
                    }
                    else
                    {
                        return new List<MCard>();
                    }
                }
                catch
                {
                    return new List<MCard>();
                }
            }
            return new List<MCard>();
        }

        /// <summary>
        /// Thêm record vào trong table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddRow<T>(T data)
        {
            if (localDB.TableExist(typeof(T).Name))
            {
                int res = localDB.Database.Insert(data);
                return res > 0;
            }
            return false;
        }

        /// <summary>
        /// Xóa bản dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool DeleteOneRow<T>(T data)
        {
            if (localDB.TableExist(typeof(T).Name))
            {
                try
                {
                    int rs = localDB.Database.Delete(data);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }


        /// <summary>
        /// Cap nhat record trong table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateRow<T>(T data)
        {
            if (localDB.TableExist(typeof(T).Name))
            {
                int res = localDB.Database.Update(data);
                return res > 0;
            }
            return false;
        }

        /// <summary>
        /// Xoa tat ca record trong table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public bool DeleteAllRow<T>()
        {
            if (localDB.TableExist(typeof(T).Name))
            {
                try
                {
                    int rs = localDB.Database.DeleteAll<T>();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
