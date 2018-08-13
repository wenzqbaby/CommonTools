using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Common.Utils.Annotation
{
    /// <summary>
    /// Created by wenzq on 2018/7/17.
    /// ע��ʵ��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Annotation<T> where T: Attribute
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="propInfo">�ṩ������ (Property) Ԫ���ݵķ��ʶ���</param>
        /// <param name="attr">���Ե�ע�����</param>
        public Annotation(PropertyInfo propInfo, T attr)
        {
            _propInfo = propInfo;
            _propName = propInfo.Name;
            _propType = propInfo.PropertyType;
            _attr = attr;
        }

        /// <summary>
        /// ���ƶ���
        /// </summary>
        /// <param name="annotation"></param>
        public Annotation(Annotation<T> annotation)
        {
            _propInfo = annotation.PropInfo;
            _propName = annotation.PropName;
            _propType = annotation.PropType;
            _attr = annotation.Attr;
        }

        private String _propName;
        /// <summary>
        /// ��������
        /// </summary>
        public String PropName
        {
            get { return _propName; }
        }

        private Type _propType;
        /// <summary>
        /// ���Ե�����
        /// </summary>
        public Type PropType
        {
            get { return _propType; }
        }

        private PropertyInfo _propInfo;
        /// <summary>
        /// �ṩ������ (Property) Ԫ���ݵķ��ʶ���
        /// </summary>
        public PropertyInfo PropInfo
        {
            get { return _propInfo; }
        }

        private T _attr;
        /// <summary>
        /// ���Ե�ע��
        /// </summary>
        public T Attr
        {
            get { return _attr; }
        }
        
    }
}
