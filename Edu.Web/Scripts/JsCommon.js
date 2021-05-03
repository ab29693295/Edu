
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}
function setURLParam(url, para_name, para_value) {

    var strNewUrl = new String();
    url = url.replace("#001", "");
    var strUrl = url;
    if (url.indexOf("#") > 1) {
        url = url.substr(0, url.indexOf("#"));
    }


    if (strUrl.indexOf("?") != -1) {
        strUrl = strUrl.substr(strUrl.indexOf("?") + 1);
        if (strUrl.toLowerCase().indexOf(para_name.toLowerCase()) == -1) {
            strNewUrl = url + "&" + para_name + "=" + para_value;
            return strNewUrl;
        } else {
            var aParam = strUrl.split("&");
            for (var i = 0; i < aParam.length; i++) {
                if (aParam[i].substr(0, aParam[i].indexOf("=")).toLowerCase() == para_name.toLowerCase()) {
                    aParam[i] = aParam[i].substr(0, aParam[i].indexOf("=")) + "=" + para_value;
                }
            }

            strNewUrl = url.substr(0, url.indexOf("?") + 1) + aParam.join("&");
            return strNewUrl;
        }

    } else {
        strUrl += "?" + para_name + "=" + para_value;
        return strUrl
    }
}

function delUrlParam(url, name) {
    var i = url;
    var reg = new RegExp("([&\?]?)" + name + "=[^&]+(&?)", "g")

    var newUrl = i.replace(reg, function (a, b, c) {
        if (c.length == 0) {
            return '';
        } else {
            return b;
        }
    });
    return newUrl;
}

function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;
}
function checkhHtml5() {
    if (typeof (Worker) !== "undefined") {
        return true;
    } else {
        return false;
    }
}
$(function () {

    $("#chkAll").click(function () {
        $("input[type=checkbox][name=chkID]").each(function () {
            $(this)[0].checked = $("#chkAll")[0].checked;
        })
    })

})
function getChk() {
    var CheckedValue = "";
    $("input[type=checkbox][name=chkID]:checked").each(function () {
        CheckedValue += $(this).val() + ",";
    })
    return CheckedValue;

}
//编码
function html_encode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&/g, ">");
    s = s.replace(/</g, "<");
    s = s.replace(/>/g, ">");
    s = s.replace(/ /g, " ");
    s = s.replace(/\'/g, "'");
    s = s.replace(/\"/g, "\"");
    s = s.replace(/\n/g, "<br>");
    return s;
}
//解码
function html_decode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/>/g, "&");
    s = s.replace(/</g, "<");
    s = s.replace(/>/g, ">");
    s = s.replace(/ /g, " ");
    s = s.replace(/'/g, "\'");
    s = s.replace(/"/g, "\"");
    s = s.replace(/<br>/g, "\n");
    return s;
}
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
            + " " + date.getHours() + seperator2 + date.getMinutes()
            + seperator2 + date.getSeconds();
    return currentdate;
}
function SetImgAutoSize(obj, width, height) {
    //var img=document.all.img1;//获取图片 
    var img = obj;
    var MaxWidth = width; //设置图片宽度界限 
    var MaxHeight = height; //设置图片高度界限 
    var HeightWidth = img.offsetHeight / img.offsetWidth; //设置高宽比 
    var WidthHeight = img.offsetWidth / img.offsetHeight; //设置宽高比 
    //if (img.readyState != "complete") return false; //确保图片完全加载  
    if ($.browser.msie) {
        if (img.readyState != "complete") return false; //确保图片完全加载 
    }
    if ($.browser.mozilla) {
        if (img.complete == false) return false;
    }
    if (img.offsetWidth > MaxWidth) {
        img.width = MaxWidth;
    }
}
