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
    /// desc:   NPA��ORM�����ӿ�
    /// </summary>
    /// <typeparam name="T">ʵ������</typeparam>
    public interface INpa<T>
    {
        /// <summary>
        /// ����ʵ�嵽���ݿ�
        /// </summary>
        /// <param name="t">ʵ�����</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int insert(T t);

        /// <summary>
        /// ִ�в������
        /// </summary>
        /// <param name="sql">SQL�������</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int insert(String sql);

        /// <summary>
        /// ִ�в������������
        /// </summary>
        /// <param name="cmd">������ָ��</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int insert(PreparedCmd cmd);

        /// <summary>
        /// ����ʵ����������Ը���ʵ�壬����������������
        /// ������Ϊ�յ�����
        /// </summary>
        /// <param name="t">ʵ�����</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int update(T t);

        /// <summary>
        /// ����ʵ����������Ը������ݣ�����������������
        /// ����Ϊ�յĽ�����Ϊnull
        /// </summary>
        /// <param name="t">ʵ�����</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int updateWithNull(T t);

        /// <summary>
        /// ���ݴ���ʵ�����ָ����������Ϊ�������������������ֶ�
        /// </summary>
        /// <param name="t">ʵ�����</param>
        /// <param name="propertys">��Ϊ��������������</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int update(T t, params String[] propertys);

        /// <summary>
        /// ����ָ����������ʵ��
        /// </summary>
        /// <param name="t">ʵ�����</param>
        /// <param name="where">SQL���Where��������</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int update(T t, List<String> conds, List<String> propertys);

        /// <summary>
        /// ִ�в������ĸ���SQL������
        /// </summary>
        /// <param name="cmd">������ָ��</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int update(PreparedCmd cmd);

        /// <summary>
        /// ִ�и���SQL���Ĳ���
        /// </summary>
        /// <param name="sql">���µ�SQL���</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int update(String sql);

        /// <summary>
        /// ����������룬��������£�����ʵ�������������Ϊ����
        /// </summary>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int insertOrUpdate(T t);

        /// <summary>
        /// ����ʵ�����������ɾ�����ݣ�����������������
        /// </summary>
        /// <param name="t"></param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int delete(T t);

        /// <summary>
        /// ִ��ɾ��SQL���Ĳ���
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int delete(String sql);

        /// <summary>
        /// ִ�в�����SQL���Ĳ���
        /// </summary>
        /// <param name="cmd">������ָ��</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        int delete(PreparedCmd cmd);

        /// <summary>
        /// ����ʵ�����Ϊ�յ�������Ϊ��������ѯ�����һ����Ϊ����
        /// ���޷��϶����򷵻ؿն���
        /// </summary>
        /// <param name="t">ʵ���������</param>
        /// <returns>ʵ�����</returns>
        T find(T t);

        /// <summary>
        /// ����ָ��������ѯʵ��
        /// ���޷��϶����򷵻ؿն���
        /// </summary>
        /// <param name="cond">SQL���Where��������</param>
        /// <returns>ʵ�����</returns>
        T find(String cond);

        /// <summary>
        /// ��ѯ����ʵ��
        /// </summary>
        /// <returns>ʵ����󼯺�</returns>
        List<T> findAll();

        /// <summary>
        /// ����ָ��������ѯ����ʵ��
        /// </summary>
        /// <param name="cond">SQL���Where��������</param>
        /// <returns>ʵ����󼯺�</returns>
        List<T> findAll(String cond);

        /// <summary>
        /// ����ʵ�����Ϊ�յ�������Ϊ��������ѯ���ж���
        /// ���޷��϶����򷵻ؿռ���
        /// </summary>
        /// <param name="t">ʵ���������</param>
        /// <returns>ʵ����󼯺�</returns>
        List<T> findAll(T t);

        /// <summary>
        /// ִ�в�ѯ���
        /// </summary>
        /// <param name="sql">��ѯ��SQL���</param>
        /// <returns>��Ӱ������������ڵ���0</returns>
        DataSet select(String sql);

        /// <summary>
        /// ִ�в�������ѯ���
        /// </summary>
        /// <param name="cmd">������ָ��</param>
        /// <returns></returns>
        DataSet select(PreparedCmd cmd);

        /// <summary>
        /// ����ʵ�����Ϊ�յ�������Ϊ��������ѯ������������������
        /// </summary>
        /// <param name="t">ʵ�����</param>
        /// <returns>��������</returns>
        int count(T t);

        /// <summary>
        /// ִ�в�ѯ������SQL���
        /// </summary>
        /// <param name="sql">Count SQL ���</param>
        /// <returns>��������</returns>
        int count(String sql);

        /// <summary>
        /// ִ�в�ѯ�����Ĳ�����SQL���
        /// </summary>
        /// <param name="cmd">��ѯ�����Ĳ�����SQL���</param>
        /// <returns>��������</returns>
        int count(PreparedCmd cmd);
    }
}
