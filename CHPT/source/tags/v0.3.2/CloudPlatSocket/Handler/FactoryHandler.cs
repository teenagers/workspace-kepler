﻿using CloudPlatSocket.Protocol;
using CloudPlatSocket.Model;
using System.Data;
using SYSModel;
using System.Collections;
using Utility.Log;

namespace CloudPlatSocket.Handler
{
    /// <summary>
    /// 车厂处理类
    /// 创建人：杨天帅
    /// 创建时间：2014.11.14
    /// 修改时间：2014.11.14
    /// </summary>
    public class FactoryHandler
    {
        #region --成员变量
        private static Hashtable htBill = new Hashtable();
        #endregion

        #region --构造函数
        public FactoryHandler()
        {
            //三包服务单
            htBill.Add("1", "ServiceOrder");
            //旧件返回单
            htBill.Add("2", "PartReturn");
            //维修结算单
            htBill.Add("3", "ServiceSettle");
            //配件采购单
            htBill.Add("4", "PartPurChase");
            //配件入库单
            htBill.Add("5", "PartStorageln");
        }
        #endregion

        #region --私有方法
        /// <summary> 处理车厂数据  
        /// </summary>
        /// <param name="ssdm"></param>
        /// <returns></returns>
        private static bool DealFactoryData(ServiceStationDataModel ssdm)
        {
            string log = "【车厂数据】  单据号:" + ssdm.BillNumber;
            log += "\r\n单据类型:" + ssdm.BillType;
            log += "\r\n操作类型:" + ssdm.OperType;
            if (ssdm.OperType == DataSources.EnumOperateObj.Data.ToString("d"))
            {
                //数据                
                if (ssdm.BillType == DataSources.EnumBillType.ServiceOrder.ToString())
                {
                    //三包服务单
                    //yuTongWebService.WebServ_YT_BusiData.QueryServiceOrder(ssdm.BillNumber);
                }
                else if (ssdm.BillType == DataSources.EnumBillType.PartReturn.ToString())
                {
                    //旧件返厂单
                    //yuTongWebService.WebServ_YT_BusiData.QueryPartReturn(ssdm.BillNumber);
                }
                else if (ssdm.BillType == DataSources.EnumBillType.ServiceSettle.ToString())
                {
                    log += "\r\n维修结算单查询";
                    Log.writeCloudLog(log);
                    return yuTongWebService.WebServ_YT_BusiData.QuerySettleAccounts(ssdm.BillNumber);
                }
                else if (ssdm.BillType == DataSources.EnumBillType.PartPurChase.ToString())
                {
                    //log = "/配件采购单查询";
                    //Log.writeLog(log);
                    ////配件采购单
                    //return yuTongWebService.WebServ_YT_BusiData(ssdm.BillNumber);                   
                }
                else if (ssdm.BillType == DataSources.EnumBillType.PartStorageIn.ToString())
                {
                    log += "\r\n配件入库单查询";
                    Log.writeCloudLog(log);
                    //配件采购单
                    return yuTongWebService.WebServ_YT_BusiData.UpLoadPartPutStore(ssdm.BillNumber);
                }
            }
            else if (ssdm.OperType == DataSources.EnumOperateObj.State.ToString("d"))
            {
                //状态
                if (ssdm.BillType == DataSources.EnumBillType.ServiceOrder.ToString())
                {
                    log += "\r\n三包服务单状态查询-CRM";
                    Log.writeCloudLog(log);
                    return yuTongWebService.WebServ_YT_BusiData.LoadOrderStatus(ssdm.BillNumber);
                }
                else if (ssdm.BillType == DataSources.EnumBillType.PartReturn.ToString())
                {
                    log += "\r\n旧件回收--状态查询-CRM";
                    Log.writeCloudLog(log);
                    return yuTongWebService.WebServ_YT_BusiData.LoadPartRetureStatus(ssdm.BillNumber);
                }
                else if (ssdm.BillType == DataSources.EnumBillType.ServiceSettle.ToString())
                {
                    log += "\r\n维修结算单状态查询";
                    Log.writeCloudLog(log);
                    return yuTongWebService.WebServ_YT_BusiData.LoadServiceSettleStatus(ssdm.BillNumber);
                }
                else if (ssdm.BillType == DataSources.EnumBillType.PartPurChase.ToString())
                {
                    log += "\r\n配件采购单状态查询";
                    Log.writeCloudLog(log);
                    return yuTongWebService.WebServ_YT_BusiData.LoadPartPurchaseStauts(ssdm.BillNumber);
                }

            }
            log += "\r\n未成功";
            Log.writeCloudLog(log);
            return false;
        }
        #endregion

        #region --公用方法
        /// <summary> 车厂数据处理 
        /// </summary>
        /// <param name="protocol"></param>
        public static void Deal(FactoryProtocol protocol)
        {
            bool result = false;
            DataTable dt = JsonHelper.JsonToDataTable(BaseCodeHelper.DeCode(protocol.Json));           
            if (dt != null && dt.Rows.Count > 0)
            {
                ServiceStationDataModel ssdm = new ServiceStationDataModel(dt.Rows[0]);
                //处理车厂数据
                result = DealFactoryData(ssdm);
            }
            //返回成功/失败信息
            ResultProtocol rp = new ResultProtocol();
            rp.StationId = protocol.StationId;
            rp.SerialNumber = protocol.SerialNumber;          
            rp.SubMessageId = protocol.SubMessageId;
            rp.TimeSpan = protocol.TimeSpan;
            rp.SerialNumberLock = true;
            if (result)
            {
                rp.Result = DataSources.EnumResultType.Success.ToString("d");
            }
            else
            {
                rp.Result = DataSources.EnumResultType.Fail.ToString("d");
            }
            ServiceAgent.AddSendQueue(rp);
        }
        #endregion
    }
}
