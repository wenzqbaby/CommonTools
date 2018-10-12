using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   NPA的ORM操作接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface INpa<T>
    {
        /// <summary>
        /// 插入实体到数据库
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int insert(T t);

        /// <summary>
        /// 执行插入语句
        /// </summary>
        /// <param name="sql">SQL插入语句</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int insert(String sql);

        /// <summary>
        /// 执行参数化插入语句
        /// </summary>
        /// <param name="cmd">参数化指令</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int insert(PreparedCmd cmd);

        /// <summary>
        /// 根据实体的主键属性更新实体，必须设置主键属性
        /// 不更新为空的属性
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int update(T t);

        /// <summary>
        /// 根据实体的主键属性更新数据，必须设置主键属性
        /// 属性为空的将更新为null
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int updateWithNull(T t);

        /// <summary>
        /// 根据传入实体对象指定的属性作为条件，更新其他属性字段
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <param name="propertys">作为条件的属性名称</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int update(T t, params String[] propertys);

        /// <summary>
        /// 根据指定条件更新实体
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <param name="where">SQL语句Where后面的语句</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int update(T t, List<String> conds, List<String> propertys);

        /// <summary>
        /// 执行参数化的更新SQL语句操作
        /// </summary>
        /// <param name="cmd">参数化指令</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int update(PreparedCmd cmd);

        /// <summary>
        /// 执行更新SQL语句的操作
        /// </summary>
        /// <param name="sql">更新的SQL语句</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int update(String sql);

        /// <summary>
        /// 不存在则插入，存在则更新，根据实体的主键属性作为条件
        /// </summary>
        /// <returns>受影响的行数，大于等于0</returns>
        int insertOrUpdate(T t);

        /// <summary>
        /// 根据实体的主键属性删除数据，必须设置主键属性
        /// </summary>
        /// <param name="t"></param>
        /// <returns>受影响的行数，大于等于0</returns>
        int delete(T t);

        /// <summary>
        /// 执行删除SQL语句的操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>受影响的行数，大于等于0</returns>
        int delete(String sql);

        /// <summary>
        /// 执行参数化SQL语句的操作
        /// </summary>
        /// <param name="cmd">参数化指令</param>
        /// <returns>受影响的行数，大于等于0</returns>
        int delete(PreparedCmd cmd);

        /// <summary>
        /// 根据实体对象不为空的属性作为条件，查询结果第一个作为对象
        /// 若无符合对象则返回空对象
        /// </summary>
        /// <param name="t">实体对象条件</param>
        /// <returns>实体对象</returns>
        T find(T t);

        /// <summary>
        /// 根据指定条件查询实体
        /// 若无符合对象则返回空对象
        /// </summary>
        /// <param name="cond">SQL语句Where后面的语句</param>
        /// <returns>实体对象</returns>
        T find(String cond);

        /// <summary>
        /// 查询所有实体
        /// </summary>
        /// <returns>实体对象集合</returns>
        List<T> findAll();

        /// <summary>
        /// 根据指定条件查询所有实体
        /// </summary>
        /// <param name="cond">SQL语句Where后面的语句</param>
        /// <returns>实体对象集合</returns>
        List<T> findAll(String cond);

        /// <summary>
        /// 根据实体对象不为空的属性作为条件，查询所有对象
        /// 若无符合对象则返回空集合
        /// </summary>
        /// <param name="t">实体对象条件</param>
        /// <returns>实体对象集合</returns>
        List<T> findAll(T t);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="sql">查询的SQL语句</param>
        /// <returns>受影响的行数，大于等于0</returns>
        DataSet select(String sql);

        /// <summary>
        /// 执行参数化查询语句
        /// </summary>
        /// <param name="cmd">参数化指令</param>
        /// <returns></returns>
        DataSet select(PreparedCmd cmd);

        /// <summary>
        /// 根据实体对象不为空的属性作为条件，查询符合条件的数据行数
        /// </summary>
        /// <param name="t">实体对象</param>
        /// <returns>数据行数</returns>
        int count(T t);

        /// <summary>
        /// 执行查询数量的SQL语句
        /// </summary>
        /// <param name="sql">Count SQL 语句</param>
        /// <returns>数据行数</returns>
        int count(String sql);

        /// <summary>
        /// 执行查询数量的参数化SQL语句
        /// </summary>
        /// <param name="cmd">查询数量的参数化SQL语句</param>
        /// <returns>数据行数</returns>
        int count(PreparedCmd cmd);
    }
}
