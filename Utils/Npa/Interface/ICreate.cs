using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   ���ݼ���������ӿ�
    /// </summary>
    public interface ICreate
    {
        /// <summary>
        /// �������ݼ���һ����ĵ�һ����������ָ�����͵Ķ���
        /// ����������Ӧ������(�շ�ʽ����)
        /// ��������ĸ��д��'_'�������ĸ��д������ΪСд��Ӧ��Ӧ��������
        /// </summary>
        /// <typeparam name="T">���ɵĶ�������</typeparam>
        /// <param name="ds">���ݼ�</param>
        /// <returns>����ʵ��</returns>
        T get<T>(DataSet ds);

        /// <summary>
        /// �������ݼ���һ����ĵ�һ����������ָ�����͵Ķ���
        /// ָ�������ж�Ӧ��������������
        /// </summary>
        /// <typeparam name="T">���ɵĶ�������</typeparam>
        /// <param name="ds">���ݼ�</param>
        /// <param name="results">���������ָ���</param>
        /// <returns>����ʵ��</returns>
        T get<T>(DataSet ds, List<ResultCmd> results);

        /// <summary>
        /// �������ݼ���һ����ĵ�һ����������ָ�����͵Ķ���
        /// �������Դ���List
        /// </summary>
        /// <typeparam name="T">���ɵĶ������ͣ������������дEquals��GetHashCode����</typeparam>
        /// <typeparam name="E">���ɵĶ�������Ƕ�׵�List����</typeparam>
        /// <param name="ds">���ݼ�</param>
        /// <param name="results">���������ָ���</param>
        /// <param name="resultCollection">���Ƕ�׼���ָ��</param>
        /// <returns>����ʵ��</returns>
        T get<T, E>(DataSet ds, List<ResultCmd> results, ResultCollectionCmd<E> resultCollection);

        /// <summary>
        /// �������ݼ���һ�������������ָ�����͵Ķ���
        /// ����������Ӧ������(�շ�ʽ����)
        /// ��������ĸ��д��'_'�������ĸ��д������ΪСд��Ӧ��Ӧ��������
        /// </summary>
        /// <typeparam name="T">���ɵĶ�������</typeparam>
        /// <param name="ds">���ݼ�</param>
        /// <returns>����ʵ�弯��</returns>
        List<T> getList<T>(DataSet ds);

        /// <summary>
        /// �������ݼ���һ�������������ָ�����͵Ķ���
        /// ָ�������ж�Ӧ��������������
        /// </summary>
        /// <typeparam name="T">���ɵĶ�������</typeparam>
        /// <param name="ds">���ݼ�</param>
        /// <param name="results">���������ָ���</param>
        /// <returns>����ʵ�弯��</returns>
        List<T> getList<T>(DataSet ds, List<ResultCmd> results);

        /// <summary>
        /// �������ݼ���һ�������������ָ�����͵Ķ���
        /// �������Դ���List
        /// </summary>
        /// <typeparam name="T">���ɵĶ������ͣ������������дEquals��GetHashCode����</typeparam>
        /// <typeparam name="E">���ɵĶ�������Ƕ�׵�List����</typeparam>
        /// <param name="ds">���ݼ�</param>
        /// <param name="results">���������ָ���</param>
        /// <param name="resultCollection">���Ƕ�׼���ָ��</param>
        /// <returns>����ʵ�弯��</returns>
        List<T> getList<T, E>(DataSet ds, List<ResultCmd> results, ResultCollectionCmd<E> resultCollection);

        /// <summary>
        /// �������ݼ���һ����ĵ�һ�е�һ����������int���ͣ�Ҫ���ֵ������ת��Ϊint����
        /// </summary>
        /// <param name="ds">���ݼ�</param>
        /// <returns></returns>
        int getCount(DataSet ds);
    }
}
