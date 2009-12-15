using System;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using eXpand.Persistent.Base.PersistentMetaData;
using eXpand.Persistent.BaseImpl.PersistentMetaData.PersistentAttributeInfos;
using eXpand.Xpo.Converters.ValueConverters;

namespace eXpand.Persistent.BaseImpl.PersistentMetaData
{
    public class PersistentCollectionMemberInfo : PersistentMemberInfo,IPersistentCollectionMemberInfo {
        public PersistentCollectionMemberInfo(Session session) : base(session) { }

        public PersistentCollectionMemberInfo(PersistentAssociationAttribute persistentAssociationAttribute):this(Session.DefaultSession,persistentAssociationAttribute)
        {
        }

        public PersistentCollectionMemberInfo(Session session, PersistentAssociationAttribute persistentAssociationAttribute)
            : base(session)
        {
            TypeAttributes.Add(persistentAssociationAttribute);
        }
        Type _collectionType;
        [Size(SizeAttribute.Unlimited)]
        [ValueConverter(typeof(TypeValueConverter))]
        [RuleRequiredField(null, DefaultContexts.Save)]
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        public Type CollectionType
        {
            get { return _collectionType; }
            set {
                SetPropertyValue("CollectionType", ref _collectionType, value);
                _collectionTypeFullName = _collectionType != null ? _collectionType.FullName : null;
                _collectionClassInfo = null;
            }
        }
        private PersistentClassInfo _collectionClassInfo;
        public PersistentClassInfo CollectionClassInfo
        {
            get
            {
                return _collectionClassInfo;
            }
            set
            {
                SetPropertyValue("CollectionClassInfo", ref _collectionClassInfo, value);
                _collectionTypeFullName = _collectionClassInfo != null ? _collectionClassInfo.PersistentAssemblyInfo.Name+"."+_collectionClassInfo.Name : null;
                _collectionType = null;
            }
        }
        private string _collectionTypeFullName;
        [Browsable(false)]
        public string CollectionTypeFullName
        {
            get
            {
                return _collectionTypeFullName;
            }
            set
            {
                SetPropertyValue("CollectionTypeFullName", ref _collectionTypeFullName, value);
            }
        }

    }
}