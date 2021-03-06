/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace ThriftApp.Lib
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class AppAgent : TBase
  {
    private string _AppCode;
    private string _Name;
    private int _Status;
    private Dictionary<string, int> _UserDict;

    public string AppCode
    {
      get
      {
        return _AppCode;
      }
      set
      {
        __isset.AppCode = true;
        this._AppCode = value;
      }
    }

    public string Name
    {
      get
      {
        return _Name;
      }
      set
      {
        __isset.Name = true;
        this._Name = value;
      }
    }

    public int Status
    {
      get
      {
        return _Status;
      }
      set
      {
        __isset.Status = true;
        this._Status = value;
      }
    }

    public Dictionary<string, int> UserDict
    {
      get
      {
        return _UserDict;
      }
      set
      {
        __isset.UserDict = true;
        this._UserDict = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool AppCode;
      public bool Name;
      public bool Status;
      public bool UserDict;
    }

    public AppAgent() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                AppCode = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Name = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I32) {
                Status = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Map) {
                {
                  UserDict = new Dictionary<string, int>();
                  TMap _map0 = iprot.ReadMapBegin();
                  for( int _i1 = 0; _i1 < _map0.Count; ++_i1)
                  {
                    string _key2;
                    int _val3;
                    _key2 = iprot.ReadString();
                    _val3 = iprot.ReadI32();
                    UserDict[_key2] = _val3;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("AppAgent");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (AppCode != null && __isset.AppCode) {
          field.Name = "AppCode";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AppCode);
          oprot.WriteFieldEnd();
        }
        if (Name != null && __isset.Name) {
          field.Name = "Name";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Name);
          oprot.WriteFieldEnd();
        }
        if (__isset.Status) {
          field.Name = "Status";
          field.Type = TType.I32;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Status);
          oprot.WriteFieldEnd();
        }
        if (UserDict != null && __isset.UserDict) {
          field.Name = "UserDict";
          field.Type = TType.Map;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.I32, UserDict.Count));
            foreach (string _iter4 in UserDict.Keys)
            {
              oprot.WriteString(_iter4);
              oprot.WriteI32(UserDict[_iter4]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("AppAgent(");
      bool __first = true;
      if (AppCode != null && __isset.AppCode) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AppCode: ");
        __sb.Append(AppCode);
      }
      if (Name != null && __isset.Name) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Name: ");
        __sb.Append(Name);
      }
      if (__isset.Status) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Status: ");
        __sb.Append(Status);
      }
      if (UserDict != null && __isset.UserDict) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("UserDict: ");
        __sb.Append(UserDict);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
