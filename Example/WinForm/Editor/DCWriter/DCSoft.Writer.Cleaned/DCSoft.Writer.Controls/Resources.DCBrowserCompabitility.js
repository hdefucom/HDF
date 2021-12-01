//alert("DCBrowserCompabitility");
//
// DCSoft 处理浏览器兼容性的代码集
//
// 2015-5-16 袁永福到此一游



var DCBrowserCompabitility = new Object();
DCBrowserCompabitility.Init = function () {
    if (this.userAgent != null) {
        return;
    }
    if (window == null || window.document == null || navigator == null ) {
        return;
    }
    var d = window.document;
    var a = navigator.appVersion.toLowerCase();
    var n = navigator.appName.toLowerCase();
    var u = navigator.userAgent.toLowerCase();
    var v = 0;

    this.userAgent = navigator.userAgent.toLowerCase();
    //alert( this.userAgent );
    // has contentEditable properties
    this.isRich = false;

    // OS
    this.isMac = (a.indexOf('mac') != -1);
    this.isWin = (((a.indexOf('win') != -1) || (a.indexOf('nt') != -1)) && !this.isMac);
    this.isLinux = (a.indexOf('linux') != -1);
    this.isiPhone = (a.indexOf('iphone') != -1);

    // Browser
    this.isOpera = (u.indexOf('opera') != -1);
    this.isIE = (a.indexOf('msie') != -1 && !this.isOpera) || a.indexOf("trident") >= 0 ;
    this.isKonq = (u.indexOf('konqueror') != -1);
    this.isSafari = (u.indexOf('webkit') != -1);
    this.isSafari2 = this.isSafari3 = false;
    this.isGecko = (u.indexOf('gecko') != -1 && !this.isSafari && !this.isKonq);
    this.isChrome = u.indexOf('chrome') >= 0;
    this.isFirefox = u.indexOf("firefox") >= 0;
    // richness
    if (this.isIE && !this.isMac) {
        v = a.substring(a.indexOf("msie") + 5, a.indexOf(";", a.indexOf("msie")));

        if (parseFloat(v) > 5.5) this.isRich = true;

    } else if (this.isGecko) {

        v = u.substring(u.indexOf("gecko/") + 6);
        v = v.substring(v, v.indexOf(" "));

        if (parseFloat(v) > 20030624) this.isRich = true;

    } else if (this.isOpera) {

        v = u.substring(u.indexOf('opera/') + 6);

        if (parseFloat(v) >= 9.0) this.isRich = true;

    } else if (this.isSafari) {
        v = u.substring(u.indexOf("webkit/") + 7);

        if (parseFloat(v) >= 312 && !this.isiPhone) this.isRich = true;


        if (u.indexOf('version/3') != -1) {
            this.isSafari3 = true;
            this.isSafari2 = false;
        } else {
            this.isSafari2 = true;
            this.isSafari3 = false;

        }
    }
};

// 根据URL加载JSON内容
// 参数：url:JSON访问地址；jsonName:数据名称
DCBrowserCompabitility.LoadJsonByUrl = function (jsonName, url) {
    if (url == null || url.length == 0) {
        eval(jsonName + " = new Object();");
    }
    var txt = DCBrowserCompabitility.GetContentByUrlNotAsync(url);
    if (txt != null && txt.length > 0) {
        eval(jsonName + " = " + txt + ";");
    }
}

//*****************************************************************************
// 使用XMLHTTP技术以GET方法获得一个页面内容,而且不采用异步模式，采用同步模式。
DCBrowserCompabitility.GetContentByUrlNotAsync = function (url) {
    var result = "";
    var xmlhttp = null;
    if (window.XMLHttpRequest) {// code for all new browsers
        xmlhttp = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {// code for IE5 and IE6
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    if (xmlhttp != null) {
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {// 4 = "loaded"
                result = xmlhttp.responseText;
            }
        };
        xmlhttp.open("GET", url, false);
        xmlhttp.send(null);
        //var result = xmlhttp.responseText;
        //return result;
        return result;
    }
    else {
    }
    return "";
};

//*****************************************************************************
// 使用XMLHTTP技术以GET方法获得一个页面内容
DCBrowserCompabitility.GetContentByUrl = function (url, promptError, readystatechangeCallback, parameter) {
    var xmlhttp = null;
    if (window.XMLHttpRequest) {// code for all new browsers
        xmlhttp = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {// code for IE5 and IE6
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    if (xmlhttp != null) {
        if (readystatechangeCallback != null) {
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4) {// 4 = "loaded"
                    readystatechangeCallback(xmlhttp.responseText, xmlhttp.status == 200, parameter, xmlhttp);
                }
            };
        }
        xmlhttp.open("GET", url, true );
        xmlhttp.send(null);
        //var result = xmlhttp.responseText;
        //return result;
        return true;
    }
    else {
        if (promptError) {
            alert("浏览器不支持XMLHTTP.");
        }
    }
    return false;
};

//*****************************************************************************
// 使用XMLHTTP技术以GET方法获得一个页面内容
DCBrowserCompabitility.PostContentByUrl = function (url, promptError, readystatechangeCallback, parameter , content ) {
    var xmlhttp = null;
    if (window.XMLHttpRequest) {// code for all new browsers
        xmlhttp = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {// code for IE5 and IE6
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    if (xmlhttp != null) {
        if (readystatechangeCallback != null) {
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4) {// 4 = "loaded"
                    readystatechangeCallback(xmlhttp.responseText, xmlhttp.status == 200, parameter, xmlhttp);
                }
            };
        }
        xmlhttp.open("POST", url, true);
        xmlhttp.send(content);
        var result = xmlhttp.responseText;
        if (result == "true")
        {
            return true;
        } else
        {
            return false;
        }
    }
    else {
        if (promptError) {
            alert("浏览器不支持XMLHTTP.");
        }
    }
    return false;
};

//使用XMLHTTP技术以POST方法获得一个页面内容并返回一个结果,而且不采用异步模式，采用同步模式。 张昊 2017-2-15 EMREDGE-28
DCBrowserCompabitility.PostContentByUrlNotAsync = function (url, promptError, content) {
    var xmlhttp = null;
    if (window.XMLHttpRequest) {// code for all new browsers
        xmlhttp = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {// code for IE5 and IE6
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    if (xmlhttp != null) {     
        xmlhttp.open("POST", url, false);
        xmlhttp.send(content);
        var result = xmlhttp.responseText;
        return result;
    }
    else {
        if (promptError) {
            alert("浏览器不支持XMLHTTP.");
        }
    }
    return "";
};

//**************************************************************************************************************
// 获得毫秒为单位的时刻数
DCBrowserCompabitility.GetDateMillisecondsTick = function (dtm) {
    var v = dtm.getFullYear();
    v = v * 12 + dtm.getMonth();
    v = v * 30 + dtm.getDate();
    v = v * 24 + dtm.getHours();
    v = v * 60 + dtm.getMinutes();
    v = v * 60 + dtm.getSeconds();
    v = v * 1000 + dtm.getMilliseconds();
    return v;
};

DCBrowserCompabitility.showModalDialog = function (url, arguments, features) {
    var dtm1 = new Date();
    alert(url);
    var result = null;
    if (window.showModalDialog) {
        result = window.showModalDialog(url, arguments, features);
    }
//    else if (openDialog) {
//        result = openDialog( url , 
//    }
    else if (window.open) {
        result = window.open(url, null, features + ";modal=yes");
    }
    var dtm2 = new Date();
    // 比较两个时间差
    var tick = DCBrowserCompabitility.GetDateMillisecondsTick(dtm2) - DCBrowserCompabitility.GetDateMillisecondsTick(dtm1);
    if (tick < 500) {
        alert("浏览器被设置为禁止弹出对话框了");
    }
    return result;
};

////*****************************************************************************
//// 使用XMLHTTP技术以POS方法发送数据并返回结果
//DCBrowserCompabitility.PostContentByUrl = function (url, postContent, promptError) {
//    var xmlhttp = null;
//    if (window.XMLHttpRequest) {// code for all new browsers
//        xmlhttp = new XMLHttpRequest();
//    }
//    else if (window.ActiveXObject) {// code for IE5 and IE6
//        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
//    }
//    if (xmlhttp != null) {
//        xmlhttp.onreadystatechange = function () {
//            if (xmlhttp.readyState == 4) {// 4 = "loaded"
//                if (xmlhttp.status == 200) {// 200 = OK
//                    // ...our code here...
//                }
//                else {
//                    if (promptError) {
//                        alert("Problem retrieving XML data");
//                    }
//                }
//            }
//        };
//        xmlhttp.open("POST", url, true);
//        xmlhttp.send(postContent);
//        var result = xmlhttp.responseText;
//        return result;
//    }
//    else {
//        if (promptError) {
//            alert("Your browser does not support XMLHTTP.");
//        }
//    }
//    return null;
//};

//DCBrowserCompabitility.parseFloat = function (text) {
//    if (this.isChrome) {
//        // 对于chorme浏览器，如果字符串出现非数字
//    }
//    else {
//        return parseFloat(text);
//    }
//};
DCBrowserCompabitility.addEventHandler = function (oTarget, sEventType, fnHandler) {
    if (oTarget == null || sEventType == null || fnHandler == null) {
        return;
    }
    if (oTarget.addEventListener) {
        oTarget.addEventListener(sEventType, fnHandler, false);
    } else if (oTarget.attachEvent) {
        oTarget.attachEvent("on" + sEventType, fnHandler);
    } else {
        oTarget["on" + sEventType] = fnHandler;
    }
};

DCBrowserCompabitility.appendEventHandler = function (oTarget, sEventName, fnHandler) {
    if (oTarget == null || sEventType == null || fnHandler == null) {
        return;
    }
    if (oTarget["on" + sEventName] == null) {
        oTarget["on" + sEventName] = function () {
            fnHandler();
        };
    }
    else {
        var oldEvent = oTarget["on" + sEventName];
        oTarget["on" + sEventName] = function () {
            oldEvent();
            fnHandler();
        };
    }
};
 

// 删除所有的子节点
DCBrowserCompabitility.RemoveAllChildNodes = function (element) {
    if (element != null) {
        while (element.firstChild != null) {
            element.removeChild(element.firstChild);
        }
    }
};

DCBrowserCompabitility.setActive = function (element) {
    //alert(element.focus);
    if (element == null) {
        return;
    }
    if (element.setActive) {
        try {
            element.setActive();
        }
        catch(ext){
        }
        return;
    }
    if (element.focus) {
        element.focus();
        return;
    }
    for (var iCount = 0; iCount < element.childNodes.length; iCount++) {
        if (element.childNodes[iCount].focus) {
            element.childNodes[iCount].focus();
            return;
        }
    }
    if (this.isChrome) {
        var input = element.ownerDocument.createElement("input");
        input.setAttribute("type", "input");
        element.appendChild(input);
        input.focus();
        element.removeChild(input);
        return;
    }
};

DCBrowserCompabitility.ScrollIntoView = function (element) {
    if (element == null) {
        return;
    }
    //    if (element.scrollIntoView) {
    //        element.scrollIntoView();
    //        return;
    //    }
    if (element.getAttribute("dc_type") != null) {
        var a = 0;
    }
    var p = element.parentNode;
    var pos = element.offsetTop;
    while (p != null && p.style) {
        if (p.style.overflowY == "auto" || p.style.overflowY == "scroll" || p == document.body) {
            p.scrollTop = pos - p.clientHeight * 0.4;
            return;
        }
        pos = pos + p.offsetTop;
        p = p.offsetParent;
    }
    //alert(element.offsetTop);
    p = element.offsetParent;
    p.scrollTop = element.offsetTop;
};

DCBrowserCompabitility.GetViewLeftInDocument = function (element) {
    if (element == null) {
        return 0;
    }
    var p = element;
    var result = 0;
    var rate = 1.0;
    while (p != null && p.tagName != "BODY") {
        if (p.offsetParent != null) {
            rate = parseFloat(p.offsetParent.style.zoom);
            if (isNaN(rate) == true) {
                rate = 1.0;
            }
        }
        result = result + p.offsetLeft * rate;
        p = p.offsetParent;
    }
    if (document.body.offsetLeft) {
        result += document.body.offsetLeft;
    }
    return result;
};

DCBrowserCompabitility.GetViewTopInDocument = function (element) {
    if (element == null) {
        return 0;
    }
    var p = element;
    var result = 0;
    var rate = 1.0;
    while (p != null && p.tagName != "BODY") {
        if (p.offsetParent != null) {
            rate = parseFloat(p.offsetParent.style.zoom);
            if (isNaN(rate) == true) {
                rate = 1.0;
            } 
        }
        result = result + p.offsetTop * rate;
        p = p.offsetParent;
    }
    if (document.body.offsetTop) {
        result += document.body.offsetTop;
    }
    return result;
};

//
// 获得元素的内部的HTML代码文本
//
DCBrowserCompabitility.GetOuterHTML = function (element) {
    if (element == null) {
        return null;
    }
    if (element.outerHTML) {
        return element.outerHTML;
    }
    if (element.nodeName == "#text") {
        return element.nodeValue;
    }

    var result = "<" + element.nodeName + " ";
    for (var iCount = 0; iCount < element.attributes.length; iCount++) {
        var name = element.attributes[iCount].nodeName;
        var v = element.attributes[iCount].nodeValue;
        result = result + " " + name + "=\"" + v + "\"";
    }
    result = result + ">" + DCBrowserCompabitility.GetInnerHTML(element) + "<\\" + element.nodeName + ">";
    return result;
};

//
// 获得元素的内部的HTML代码文本
//
DCBrowserCompabitility.GetInnerHTML = function (element) {
    if (element == null) {
        return null;
    }
    var result = element.innerHTML;
    //alert(resul);
    return result;
};

//
// 获得元素的内部的纯文本
//
DCBrowserCompabitility.GetInnerText = function (element) {
    if (element == null) {
        return null;
    }
    if (element.nodeName) {
        if (element.nodeName == "#text") {
            // 纯文本节点
            return element.nodeValue;
        }
    }
    if (element.innerText) {
        return element.innerText;
    }
    if (element.textContent) {
        return element.textContent;
    }
    return element.nodeValue;
};

//
// 设置元素的内部的纯文本
//
DCBrowserCompabitility.SetInnerText = function (element, text) {
    if (element == null) {
        return null;
    }
    if (element.nodeName) {
        if (element.nodeName == "#text") {
            // 纯文本节点
            element.nodeValue = text;
        }
        if (element.nodeName == "INPUT" || element.nodeName == "TEXTAREA") {
            element.value = text;
        }
        else if (element.nodeName == "SELECT") {
            var opts = element.options;
            for (var iCount = 0; iCount < opts.length; iCount++) {
                var opt = opts[iCount];
                if (opt.value == text || opt.text == text) {
                    element.selectedIndex = iCount;
                    //opt.selected = true;
                    break;
                }
            }
        }
        else {
            DCBrowserCompabitility.ClearChild(element);
            if (text != null && text.length > 0) {
                element.appendChild(document.createTextNode(text));
            }
        }
    }
};


//
// 删除指定元素的所有子元素
// 
DCBrowserCompabitility.ClearChild = function (element) {
    if (element != null) {
        while (element.firstChild != null) {
            element.removeChild(element.firstChild);
        }
    }
},

//
// 设置指定元素的内部HTML代码
// 
DCBrowserCompabitility.SetInnerHTML = function (element, strHtml) {
    var fscrollLeft = element.scrollLeft;
    var fscrollTop = element.scrollTop;
    while (element.firstChild != null) {
        element.removeChild(element.firstChild);
    }
    if (strHtml != null && strHtml.length > 0 ) {
        if (element.insertAdjacentHTML){//this.isIE) {
            element.insertAdjacentHTML("afterBegin", strHtml);
        }
        else {
            var range = element.ownerDocument.createRange();
            range.selectNodeContents(element);
            range.collapse(true);
            var df = range.createContextualFragment(strHtml);
            element.appendChild(df);
        }
    }
};

// 根据HTML代码创建文档节点
DCBrowserCompabitility.createContextualFragment = function (html) {
    if (html == null || html.length == 0) {
        return null;
    }
    var range = document.createRange();
    var df = range.createContextualFragment(html);
    return df;
};

//
// 设置指定框架的元素的内部HTML代码
//
DCBrowserCompabitility.SetFrameInnerHTML = function (frameElement, strHtml) {
    //alert(strHtml.length);
    if (frameElement != null && frameElement.contentWindow) {
        frameElement.contentWindow.document.write(strHtml);
        frameElement.contentWindow.document.close();
    }
};


//
// 设置指定框架元素的内容HTML代码
//
DCBrowserCompabitility.GetFrameInnerHTML = function (frameElement) {
    if (frameElement != null && frameElement.contentWindow) {
        //var bodyElement = frameElement.contentWindow.document.body;
        var txt = frameElement.contentWindow.document.documentElement.innerHTML;
        txt = "<html>" + txt + "</html>";
        //alert(txt);
        return txt;
    }
    return null;
};

//
// 设置指定元素的内部HTML代码，并保持内容视图滚动不变
//
DCBrowserCompabitility.SetInnerHTMLWithoutScroll = function (element, strHtml) {

    var fscrollLeft = element.scrollLeft;
    var fscrollTop = element.scrollTop;
    while (element.firstChild != null) {
        element.removeChild(element.firstChild);
    }
    if (strHtml != null) {
        if (this.isIE) {
            element.insertAdjacentHTML("afterBegin", strHtml);
        }
        else {
            var range = element.ownerDocument.createRange();
            range.selectNodeContents(element);
            range.collapse(true);
            var df = range.createContextualFragment(strHtml);
            element.appendChild(df);
        }
        element.scrollLeft = fscrollLeft;
        element.scrollTop = fscrollTop;
    }
};

// 在容器元素的指定位置插入HTML代码
DCBrowserCompabitility.inertHTML = function (element, index, strHtml, htmlMode) {
    if (element == null) {
        return false;
    }
    if (index < 0) {
        index = 0;
    }
    if (index >= element.childNodes.length) {
        index = element.childNodes.length - 1;
    }
    var df = null;
    if (htmlMode) {
        // HTML模式
        var range = document.createRange();
        range.setStartBefore(element);
        df = range.createContextualFragment(strHtml);
    }
    else {
        // 纯文本模式
        df = document.createTextNode(strHtml);
    }
    if (element.childNodes.length == 0) {
        element.appendChild(df);
    }
    else {
        if (index == 0) {
            element.insertBefore(df, element.firstChild);
        }
        else if (index >= element.childNodes.length) {
            element.appendChild(df);
        }
        else {
            element.insertBefore(df, element.childNodes[index]);
        }
    }
};

//
// 在指定的位置插入HTML代码
//
DCBrowserCompabitility.insertAdjacentHTML = function (element, where, strHtml) {
    if (strHtml != null) {
        if (element.insertAdjacentHTML) {
            element.insertAdjacentHTML(where, strHtml);
        }
        else {
            var range = document.createRange();
            range.setStartBefore(element);
            var df = range.createContextualFragment(strHtml);
            switch (where) {
                case "beforeBegin":
                    element.parentNode.insertBefore(df, element);
                    break;
                case "afterBegin":
                    element.insertBefore(df, element.firstChild);
                    break;
                case "beforeEnd":
                    element.appendChild(df);
                    break;
                case "afterEnd":
                    if (element.nextSibling == null)
                        element.parentNode.appendChild(df);
                    else
                        element.parentNode.insertBefore(df, element.nextSibling);
                    break;
            } //switch
        }
    }
};

//**************************************************************************************************************
// 获得节点在其父节点中的子节点序号
DCBrowserCompabitility.GetNodeIndex = function (node) {
    if (node == null || node.parentNode == null) {
        return -1;
    }
    var nodes = node.parentNode.childNodes;
    for (var iCount = 0; iCount < nodes.length; iCount++) {
        if (nodes[iCount] == node) {
            return iCount;
        }
    }
    return -1;
}


//**************************************************************************************************************
// 移动插入点到指定元素前
DCBrowserCompabitility.MoveCaretToIndex = function (element, index) {
    if (element == null) {
        return;
    }
    if (element.nodeName == "INPUT"
        || element.nodeName == "SELECT"
        || element.nodeName == "TEXTAREA") {
        if (element.focus) {
            element.focus();
        }
        if (element.select) {
            element.select();
        }
        if (element.setActive) {
            element.setActive();
        }
        if (element.value != null) {
            var len = element.value.length;
            if (index >= 0 && index <= len) {
                if (element.type == "input" || element.type == "password") {
                    element.selectionStart = index;
                    element.selectionEnd = index;
                }
            }
        }
    }
    else {
        var sParent = element.parentNode;
        while (sParent != null) {
            if (sParent.clientHeight < sParent.scrollHeight) {
                break;
            }
            sParent = sParent.parentNode;
        }
        if (sParent == null) {
            sParent = document.body;
        }
        var sLeft = sParent.scrollLeft;
        var sTop = sParent.scrollTop;
        if (element.focus) {
            element.focus();
        }
        if (element.getClientRects) {
            var node2 = element;
            if (index >= 0 && index < element.childNodes.length) {
                node2 = element.childNodes[index];
                if (!node2.getClientRects) {
                    node2 = element;
                }
            }
            var rects = node2.getClientRects();
            if (rects.length > 0) {
                var sel2 = DCBrowserCompabitility.getSelection();
                var range = null;
                if (document.createRange) {
                    range = document.createRange();
                }
                else if (document.body.createRange) {
                    range = document.body.createRange();
                }
                //                if (range.moveToPoint) {
                //                    range.moveToPoint(
                //                        rects[0].left + document.body.scrollLeft,
                //                        rects[0].top + document.body.scrollTop);
                //                    sel2.addRange(range);
                //                    return;
                //                }
            }
        }

        var sel = DCBrowserCompabitility.getSelection();
        //var range = document.createRange();
        //range.setStart(element, index);
        //sel.removeAllRanges();
        //sel.addRange(range);
        //sel.collapseToStart();
        if (sel.collapse) {
            sel.collapse(element, index);
        }

        if (sel.anchorNode == null) {
            sel = DCBrowserCompabitility.getSelection();
            var range = null;
            if (document.createRange) {
                range = document.createRange();
            }
            else {
                range = sel.createRange();
            }
            if (range.setStart) {
                range.setStart(element, index);
            }
            else {
                // 插入一个临时的按钮 
                if (element.nodeName != "#text") {
                    var btn = document.createElement("input");
                    btn.type = "button";
                    DCDomTools.insertChildNode(element, index, btn);
                    if (btn.focus) {
                        btn.focus();
                    }
                    if (btn.setActive) {
                        btn.setActive();
                    }
                    element.removeChild(btn);
                }
            }
            //            else if (range.moveToElementText) {
            //                range.moveToElementText(element);
            //            }
            if (sel.removeAllRanges) {
                sel.removeAllRanges();
                sel.addRange(range);
            }
        }
        sParent.scrollLeft = sLeft;
        sParent.scrollTop = sTop;
    }
    return;
};

//**************************************************************************************************************
// 移动插入点到指定元素前
DCBrowserCompabitility.MoveCaretTo = function (element) {
    if (element == null) {
        return;
    }
    var sel = DCBrowserCompabitility.getSelection();
    if (sel.collapse) {
        try {
            sel.collapse(element, 0);
            return;
        }
        catch (e) {
        }
        var range = document.createRange();
        range.selectNode(element);
        sel.removeAllRanges();
        sel.addRange(range);
        return;
        //        if (element.nodeName == "SELECT" || element.nodeName == "INPUT") {
        //            var p = element.parentNode;
        //            var index = DCBrowserCompabitility.GetNodeIndex(element);
        //            sel.colapse(p, index);
        //        }
        //        else {
        //            sel.collapse(element, 0);
        //        }
    }
    return;
};

//**************************************************************************************************************
// 移动插入点到指定元素前
DCBrowserCompabitility.MoveCaretToEnd = function (element) {
    if (element == null) {
        return;
    }
    var sel = DCBrowserCompabitility.getSelection();
    if (sel.collapse) {
        var index = 0;
        if (element.nodeName == "#text") {
            var txt = element.nodeValue;
            if (txt == null || txt.length == 0) {
                sel.collapse(element, 0);
            }
            else {
                sel.collapse(element, txt.length);
            }
        }
        else if (element.nodeName == "INPUT"
             && element.type == "text"
            || element.nodeName == "TEXTAREA") {
            element.focus();
            element.select();
            var txt = element.value;
            if (txt != null || txt.length > 0) {
                element.selectionStart = txt.length;
                element.selectionEnd = txt.length;
            }
        }
        else {
            var child = element.lastChild;
            while (child != null) {
                if (child.nodeName == "#text") {
                    DCBrowserCompabitility.MoveCaretToEnd(child);
                    return;
                }
                else if (child.nodeName == "INPUT" && child.type == "text"
                    || child.nodeName == "TEXTAREA") {
                    DCBrowserCompabitility.MoveCaretToEnd(child);
                    return;
                }
                child = child.lastChild;
            }//while
            sel.collapse(element, element.childNodes.length);
        }
        //        var txt = DCBrowserCompabitility.GetInnerText(element);
        //        if (txt != null) {
        //            index = txt.length;
        //        }
        //        sel.collapse(element, index);
    }
    return;
};
 
//**************************************************************************************************************
// 获得选中区域信息对象
DCBrowserCompabitility.getSelection = function (element) {
    var doc = document;
    if (element != null) {
        if ( element.nodeName == "#document") {
            doc = element;
        }
        else {
            doc = element.ownerDocument;
        }
    }
    if (doc == null) {
        doc = document;
    }
    if (doc.getSelection) {
        return doc.getSelection();
    }
    if (doc.selection) {
        return doc.selection;
    }
    if (doc.parentWindow) {
        if (doc.parentWindow.getSelection) {
            return doc.parentWindow.getSelection();
        }
    }
    if (window.getSelection) {
        return window.getSelection();
    }
    return null;
};

DCBrowserCompabitility.clearSelection = function () {
    var sel = DCBrowserCompabitility.getSelection(null);
    if (sel != null) {
        if (sel.anchorNode == sel.focusNode
            && sel.anchorOffset == sel.focusOffset) {
            // 无需操作
            return;
        }
        if (sel.collapseToStart) {
            sel.collapseToStart();
        }
        else if (sel.createTextRange) {
            var rng = sel.createTextRange();
            rng.collapse(true);
        }
    }
};
//***********************************************************************************
// 判断插入点是否在指定容器中
DCBrowserCompabitility.ContainsSelection = function (element) {
    var sel = DCBrowserCompabitility.getSelection(element);
    if (sel.focusNode != null) {
        var node = sel.focusNode;
        while (node != null) {
            if (node == element) {
                return true;
            }
            node = node.parentNode;
        }
    }
    return false;
};
 
//
// 初始化浏览器兼容性处理器
//
DCBrowserCompabitility.Init();
 