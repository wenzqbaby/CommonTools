using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Common.Utils.Annotation
{
    /// <summary>
    /// Created by wenzq on 2018/7/17.
    /// 注解实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Annotation<T> where T: Attribute
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="propInfo">提供对属性 (Property) 元数据的访问对象</param>
        /// <param name="attr">属性的注解对象</param>
        public Annotation(PropertyInfo propInfo, T attr)
        {
            _propInfo = propInfo;
            _propName = propInfo.Name;
            _propType = propInfo.PropertyType;
            _attr = attr;
        }

        /// <summary>
        /// 复制对象
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
        /// 属性名称
        /// </summary>
        public String PropName
        {
            get { return _propName; }
        }

        private Type _propType;
        /// <summary>
        /// 属性的类型
        /// </summary>
        public Type PropType
        {
            get { return _propType; }
        }

        private PropertyInfo _propInfo;
        /// <summary>
        /// 提供对属性 (Property) 元数据的访问对象
        /// </summary>
        public PropertyInfo PropInfo
        {
            get { return _propInfo; }
        }

        private T _attr;
        /// <summary>
        /// 属性的注解
        /// </summary>
        public T Attr
        {
            get { return _attr; }
        }
        
    }
}
