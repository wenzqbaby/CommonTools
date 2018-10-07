using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common.Utils.Npa.cmd;

namespace Common.Utils.Npa.Interface
{
    public interface ICreate
    {
        T get<T>(DataSet ds);

        T get<T>(DataSet ds, List<ResultCmd> results);

        T get<T, E>(DataSet ds, List<ResultCmd> results, ResultCollectionCmd<E> resultCollection);

        List<T> getList<T>(DataSet ds);

        List<T> getList<T>(DataSet ds, List<ResultCmd> results);

        List<T> getList<T, E>(DataSet ds, List<ResultCmd> results, ResultCollectionCmd<E> resultCollection);
    }
}
