﻿#region Copyright (C) 2016 Kevin (OS系列开源项目)

/***************************************************************************
*　　	文件功能描述：公众号功能接口 ——菜单管理部分
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2017-1-18
*       
*****************************************************************************/

#endregion

using System.Collections.Generic;
using Newtonsoft.Json;
using OS.Http;
using OS.Http.Models;
using OS.Social.WX.Offcial.Basic.Mos;

namespace OS.Social.WX.Offcial.Basic
{
    /// <summary>
    /// 公号管理
    /// </summary>
    public partial class WxOffcialApi
    {


        #region 正常菜单管理
        /// <summary>
        ///    添加或更新公号菜单
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public WxBaseResp AddOrUpdateMenu(List<WxMenuButtonInfo>  buttons)
        {
            var req=new OsHttpRequest();
            req.HttpMothed=HttpMothed.POST;
            req.AddressUrl = string.Concat(m_ApiUrl, "/cgi-bin/menu/create");
            req.CustomBody = JsonConvert.SerializeObject(new {button= buttons } , Formatting.Indented,
                new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});


            return RestCommonOffcial<WxBaseResp>(req);
        }


        /// <summary>
        /// 获取菜单设置
        /// </summary>
        /// <returns></returns>
        public WxGetMenuResp GetMenu()
        {
            var req=new OsHttpRequest();

            req.HttpMothed=HttpMothed.GET;
            req.AddressUrl = string.Concat(m_ApiUrl, "/cgi-bin/menu/get");

            return RestCommonOffcial<WxGetMenuResp>(req);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <returns></returns>
        public WxBaseResp DeleteMenu()
        {
            var  req=new OsHttpRequest();
            req.HttpMothed=HttpMothed.GET;
            req.AddressUrl = string.Concat(m_ApiUrl, "/cgi-bin/menu/delete");

            return RestCommonOffcial<WxBaseResp>(req);
        }
        #endregion


        #region 个性化菜单
        /// <summary>
        ///   添加定制菜单
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public WxAddCustomMenuResp AddCustomMenu(List<WxMenuButtonInfo> buttons,WxMenuMatchRule rule )
        {
            var req = new OsHttpRequest();
            req.HttpMothed = HttpMothed.POST;
            req.AddressUrl = string.Concat(m_ApiUrl, "/cgi-bin/menu/addconditional");
            req.CustomBody = JsonConvert.SerializeObject(new { button = buttons, matchrule=rule }, 
                Formatting.Indented,new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });


            return RestCommonOffcial<WxAddCustomMenuResp>(req);
        }

        #endregion
    }
}
