

// DCWriter 的ＷＥＢ控件使用的ＪＳ代码，编制袁永福2015-5-24
    //debugger;
var DCWriterControllerClass = new Object();

//**************************************************************************************************************
// 输出一些客户端调试信息
DCWriterControllerClass.WriteDebugInfo = function () {
    if (navigator != null) {
        document.writeln("<br/>NavigatorAppVersion=" + navigator.appVersion);
        document.writeln("<br/>NavigatorAppName=" + navigator.appName);
        document.writeln("<br/>NavigatorUserAgen=" + navigator.userAgent);
    }
    document.close();
}

//// 删除HTML中的<script>元素
//DCWriterControllerClass.removeScriptElement = function (htmlString) {
//    if (htmlString == null || htmlString.length == 0) {
//        return htmlString;
//    }
//    while (true) {
//        var match = false;
//        var index1 = htmlString.indexOf("<script");
//        if (index1 >= 0) {
//            var index2 = htmlString.indexOf("</script>", index1);
//            if (index2 > 0) {
//                var txt = htmlString.substr(0, index1);
//                var txt2 = htmlString.substr(index2 + 9 );
//                htmlString = txt + txt2;
//                match = true;
//            }
//        }
//        if (match == false) {
//            break;
//        }
//    }
//    return htmlString;
//};

// 使用AJAX打开文件
DCWriterControllerClass.LoadDocumentFormFile = function (rootElement, fileName, fileFormat) {
    if (fileFormat == null) {
        fileFormat = "xml";
    }
    if (fileName == null || fileName.length == 0) {
        // 传入的文件名为空
        return false;
    }
    var servicePageUrl = rootElement.getAttribute("servicepageurl");
    rootElement.startTimeForLoadDocumentFormFile = new Date();
    rootElement.ShowAppProcessing();
    var url = servicePageUrl + "?dcwritergetfulldocumenthtml=" + encodeURI(fileName)
        + "&fileformat=" + fileFormat
        + "&controlinstanceid=" + rootElement.getAttribute("controlinstanceid")
        + "&contentrendermode=" + rootElement.getAttribute("contentrendermode") + "&random=" + Math.random();
    url = url.replace(/\+/g, "%2B");  //文档传参数转译文档名中的“+”
    var scrollPositionX = 0;
    var scrollPositionY = 0;
    var descDoc = rootElement.frameWindow.document;
    rootElement.dcondocumentload_HiddenProcessing = function () {
        //文档加载后隐藏等待界面
        rootElement.HiddenAppProcessing();
        var tickStart = rootElement.frameWindow.DCDomTools.GetDateMillisecondsTick(rootElement.startTimeForLoadDocumentFormFile);
        var tick = rootElement.frameWindow.DCDomTools.GetDateMillisecondsTick(new Date());
        rootElement.clientTicks = tick - tickStart;
    };
    if (rootElement.preserveScrollPosition == true && descDoc.body != null) {
        scrollPositionX = descDoc.body.scrollLeft;
        scrollPositionY = descDoc.body.scrollTop;
    }
    var func = function (responseText, httpOK) {
        if (responseText == null || responseText.length == 0) {
            rootElement.HiddenAppProcessing();
            responseText = rootElement.GetDCWriterString("JS_ReturnNoneContent_Url", servicePageUrl);
        }
        DCWriterControllerClass.loadHtmlContent(rootElement, responseText);
        if (httpOK == false) {
            // HTTP不是正常的，隐藏等待界面。
            rootElement.HiddenAppProcessing();
        }
        if (rootElement.preserveScrollPosition == true
            && (scrollPositionX > 0 || scrollPositionY > 0)) {
            var funcScroll = function () {
                if (descDoc.body == null) {
                    // 文档还没加载完成，等会再运行
                    window.setTimeout(funcScroll, 200);
                    return;
                }
                if (descDoc.body.scrollLeft == 0
                   && descDoc.body.scrollTop == 0) {
                    // 没有被用户滚动过，试图设置加载文档前的滚动位置。
                    descDoc.body.scrollLeft = scrollPositionX;
                    descDoc.body.scrollTop = scrollPositionY;
                }
            }
            window.setTimeout(funcScroll, 300);
        }
        //rootElement.HiddenAppProcessing();
        return;
    };
    var result = DCBrowserCompabitility.GetContentByUrl(url, false, func);
}

DCWriterControllerClass.WriteFrameContent = function (rootElement, text) {
    if (rootElement == null) {
        return;
    }
    var frame = document.getElementById(rootElement.id + "_Frame");
    if (frame != null) {
        var doc = frame.contentWindow.document;
        doc.write(text);
        doc.close();
    }
};

// 加载内容
DCWriterControllerClass.loadContent = function (rootElement) {
    //var func = function () {
        var htmlSourceElement = null;
        for (var iCount = 0; iCount < rootElement.childNodes.length; iCount++) {
            var node = rootElement.childNodes[iCount];
            if (node.nodeName == "TEXTAREA" && node.getAttribute("dctype") == "DCHtmlSource") {
                htmlSourceElement = node;
                break;
            }
        } //for

        if (htmlSourceElement == null) {
            // 没有HTML来源，退出
            return false;
        }
        var optBack = rootElement.frameDocument.Options;
        DCBrowserCompabitility.SetFrameInnerHTML(rootElement.frameElement, htmlSourceElement.value);
        htmlSourceElement.parentNode.removeChild(htmlSourceElement);
        rootElement.frameDocument.Options = optBack;

        rootElement.frameDocument = rootElement.frameElement.contentWindow.document;
        rootElement.contentBody = rootElement.frameElement.contentWindow.document.body;

        return true;
    //}
    //window.setTimeout(func, 1000);
}

    // 加载内容
DCWriterControllerClass.loadHtmlContent = function (rootElement, htmlContent) {
    if (rootElement.checkResponseContent(htmlContent) == false) {
        return false;
    }

    var optBack = rootElement.frameDocument.Options;
    DCBrowserCompabitility.SetFrameInnerHTML(rootElement.frameElement, htmlContent);
    rootElement.frameDocument.Options = optBack;

    rootElement.frameDocument = rootElement.frameElement.contentWindow.document;
    rootElement.contentBody = rootElement.frameElement.contentWindow.document.body;
    rootElement.frameElement.contentWindow.document.WriterControl = rootElement;
    //        var str = "";
    //        for (var iCount = 0; iCount < 10000000; iCount++) {
    //            str = str + "a";
    //        }
    return true;
    //}
    //window.setTimeout(func, 1000);
}


DCWriterControllerClass.InitController = function (rootElement) {
    if (rootElement == null) {
        return false;
    }
    // 设置控件处于鼠标拖拽滚动模式
    rootElement.setMouseDragScrollMode = function (setValue) {
        var funcSetCursor = function () {
            var doc = rootElement.frameWindow.document;
            var tab = doc.getElementById("dctable_AllContent");
            if (tab != null) {
                if (setValue) {
                    tab.style.cursor = "";
                }
                else {
                    tab.style.cursor = "auto";
                }
            }

        }
        if (this.frameWindow.document.body == null) {
            // 文档还未加载完成
            this.dcondocumentload_SetDragScrollMode = function () {
                DCDomTools.setMouseDragScrollMode(
                    this.body,
                    setValue);
                funcSetCursor();
            }
            return;
        }
        else {
            this.dcondocumentload_SetDragScrollMode = null;
        }
        if (this.frameWindow != null
            && this.frameWindow.DCDomTools != null
            && this.frameWindow.document.body != null) {
            var result = this.frameWindow.DCDomTools.setMouseDragScrollMode(
                this.frameWindow.document.body,
                setValue);
            funcSetCursor();
            return result;
        }
        return false;
    };

    //    rootElement.IsMouseDragScrollMode = function () {
    //        if (this.frameWindow != null
    //            && this.frameWindow.DCDomTools != null
    //            && this.frameWindow.document.body != null) {
    //            return this.frameWindow.DCDomTools.IsMouseDragScrollMode(
    //                this.frameWindow.document.body);
    //        }
    //        return false;
    //    };


    rootElement.raiseDCClientEvent = function (eventObject, eventName) {
        if (eventObject != null && eventObject.cancelBubble == true) {
            // 参数指明不再触发后续事件
            return;
        }
        var func = this[eventName];
        if (typeof (func) == "function") {
            return func(eventObject);
        }
        var script = this.getAttribute(eventName);
        if (script != null && script.length > 0) {
            return eval(script);
        }
    }
    //    var htmlSourceElement = null;
    //    for (var iCount = 0; iCount < rootElement.childNodes.length; iCount++) {
    //        var node = rootElement.childNodes[iCount];
    //        if (node.nodeName == "TEXTAREA" && node.getAttribute("dctype") == "DCHtmlSource") {
    //            htmlSourceElement = node;
    //            break;
    //        }
    //    } //for

    //    if (htmlSourceElement == null) {
    //        // 没有HTML来源，退出
    //        rootElement.frameDocument.Options = rootElement.DocumentOptions;
    //        return false;
    //    }

    //拖放对象,触发对象
    this.id = rootElement.id;
    rootElement.frameElement = document.getElementById(rootElement.id + "_Frame");

    //DCBrowserCompabitility.SetFrameInnerHTML(rootElement.frameElement, htmlSourceElement.value);
    //htmlSourceElement.parentNode.removeChild(htmlSourceElement);

    rootElement.frameDocument = rootElement.frameElement.contentWindow.document;
    rootElement.contentBody = rootElement.frameElement.contentWindow.document.body;
    rootElement.frameWindow = rootElement.frameElement.contentWindow;
    rootElement.servicePageURL = rootElement.getAttribute("ServicePageURL");
    //rootElement.frameElement.RootWriterControl = rootElement;

    rootElement.frameDocument.Options = rootElement.DocumentOptions;
    // 加载文件
    rootElement.LoadDocumentFromFile = function (fileName, fileFormat) {
        if (rootElement.checkShowingDialog() == false) {
            // 正在执行其他的操作界面，无法执行本操作。
            return null;
        }
        return DCWriterControllerClass.LoadDocumentFormFile(this, fileName, fileFormat);
    };


    //获得服务器端的性能相关的信息
    rootElement.getServerPerformances = function () {
        var result = new Object();
        if (rootElement.frameElement.contentWindow.document.body != null) {
            result.characters = parseInt(rootElement.frameElement.contentWindow.document.body.getAttribute("serverchars"));
            result.serverTicks = parseInt(rootElement.frameElement.contentWindow.document.body.getAttribute("serverticks"));
            result.clientTicks = rootElement.clientTicks;
            return result;
        }
        else {
            return 0;
        }
    }

    // 检查返回内容使用的函数
    rootElement.checkResponseContent = function (htmlContent) {
        if (rootElement.frameElement.contentWindow.DCWriterControllerEditor) {
            if (rootElement.frameElement.contentWindow.DCWriterControllerEditor.checkResponseContent(htmlContent) == false) {
                rootElement.HiddenAppProcessing();
                return false;
            }
        }
        return true;
    };

    // 控件文档内容是否改变
    rootElement.getModified = function () {
        if (rootElement.frameWindow.DCMultiDocumentManager == null) {
            return true;
        }
        return rootElement.frameWindow.DCMultiDocumentManager.getModified();
    }

    rootElement.getAllSubDocumentInfos = function () {
        if (rootElement.frameWindow.DCMultiDocumentManager == null) {
            return null;
        }
        return rootElement.frameWindow.DCMultiDocumentManager.getAllDocumentInfos();
    };

    // 获得所有的子文档元素对象
    rootElement.getSubDocuments = function () {
        if (rootElement.frameWindow.DCSubDocumentManager == null) {
            return null;
        }
        return rootElement.frameWindow.DCSubDocumentManager.getSubDocuments();
    }

    rootElement.selectSubDocument = function (index) {
        if (rootElement.frameWindow.DCMultiDocumentManager == null) {
            return null;
        }
        return rootElement.frameWindow.DCMultiDocumentManager.selectDocument
    };

    rootElement.getCurrentSubDocumentInfo = function () {
        if (rootElement.frameWindow.DCMultiDocumentManager == null) {
            return null;
        }
        return rootElement.frameWindow.DCMultiDocumentManager.getCurrentInfo();
    };

    // 执行编辑器命令
    rootElement.DCExecuteCommand = function (commandName, showUI, parameter) {
        if (rootElement.checkShowingDialog() == false) {
            return null;
        }
        if (rootElement.frameWindow.DCWriterCommandMananger != null) {
            return rootElement.frameWindow.DCWriterCommandMananger.DCEexecuteCommand(commandName, showUI, parameter);
        }
        else {
            return null;
        }
    };

    rootElement.SetContentHtml = function (html) {
        DCBrowserCompabitility.SetFrameInnerHTML(this.frameElement, html);
    };

    //    rootElement.LoadDocumentFormFile = function (fileName, fileFormat) {
    //        return DCWriterControllerClass.LoadDocumentFormFile(rootElement, fileName, fileFormat);
    //    };

    rootElement.GetContentHtml = function () {
        if (rootElement.frameWindow.WriterCommandModuleFile != null) {
            var html = rootElement.frameWindow.WriterCommandModuleFile.GetFileContentHtml();
            if (html != null && html.length > 0) {
                // 这是一个BUG之源，不过触发的概率很低 ###########################################
                html = html.replace(/[<]/g, "[3#$~!]");
                html = html.replace(/[>]/g, "[!$~$#]");
                html = html.replace(/[&]/g, "[!$~$%]");
            }
            return html;
        }
        else {
            return "";
        }

    };

    var insertImageButtonID = rootElement.getAttribute("insertimagebuttonid");
    if (insertImageButtonID != null
                    && insertImageButtonID.length > 0
                    && document.getElementById(insertImageButtonID) != null) {
        // 定义一个函数，将透明的上传图片的内置框架元素放置到上传图片按钮上面。
        var funcBindInsertImageButton = function () {
            var frameID = rootElement.id + "_UploadFrameSimple";
            var frameElement = document.getElementById(frameID);
            if (frameElement == null) {
                frameElement = document.createElement("iframe");
                frameElement.id = frameID;
                frameElement.style.opacity = "0.01";
                frameElement.style.position = "absolute";
                frameElement.scrolling = "no";
                rootElement.appendChild(frameElement);
            }
            if (rootElement.isShowingDialog()) {
                // 正在显示对话框，无法执行操作。
                frameElement.style.display = "none";
                return;
            }
            else {
                frameElement.style.display = "";
            }
            if (frameElement.contentWindow.document.getElementById("form1") == null) {
                // 内容为空，则设置内容
                var htmlSrc = rootElement.servicePageURL + "?dcwriteruploadfile=2";
                frameElement.src = htmlSrc;
                var imgID = "img" + Math.random();
                frameElement.fileID = imgID;
                frameElement.accept = "image/png,image/gif,image/jpeg,image/bmp";
                // 提交操作回调函数
                frameElement.okCallback = function () {
                    if (rootElement.checkShowingDialog() == false) {
                        return false;
                    }
                    if (rootElement.frameWindow.DCFileUploadManager.CanUploadImage(true) == false) {
                        return false;
                    }
                    rootElement.frameWindow.DCFileUploadManager.UploadImageCallback(imgID);
                    return true;
                };
            }
            var btn2 = document.getElementById(insertImageButtonID);
            if (btn2 == null) {
                // 没找到按钮
                frameElement.style.display = "none";
                return;
            }
            else {
                frameElement.style.dispaly = "";
            }
            frameElement.style.left = DCBrowserCompabitility.GetViewLeftInDocument(btn2) + "px";
            frameElement.style.top = DCBrowserCompabitility.GetViewTopInDocument(btn2) + "px";
            frameElement.style.width = btn2.offsetWidth + "px";
            frameElement.style.height = btn2.offsetHeight + "px";
            frameElement.style.border = "1px solid black";
            frameElement.style.zIndex = 100004;
        };
        window.setInterval(funcBindInsertImageButton, 400);
    }

    // 显示控件的遮盖面板 *********************************************************************
    rootElement.showMaskPanel = function (contentElement) {
        var mask = document.getElementById(this.id + "_ControlMask");
        if (mask != null) {
            mask.style.display = "";
            var left1 = DCBrowserCompabitility.GetViewLeftInDocument(this);
            var top1 = DCBrowserCompabitility.GetViewTopInDocument(this);
            mask.style.left = left1 + "px";
            mask.style.top = top1 + "px";
            mask.style.width = this.offsetWidth + "px";
            mask.style.height = this.offsetHeight + "px";
            mask.currentContentElement = contentElement;
            if (contentElement != null) {
                contentElement.style.display = "";
                contentElement.style.position = "absolute";
                var v = mask.offsetLeft + (mask.offsetWidth - contentElement.offsetWidth) / 2;
                contentElement.style.left = v + "px";
                v = mask.offsetTop + (mask.offsetHeight - contentElement.offsetHeight) / 2;
                contentElement.style.top = v + "px";
                contentElement.style.zIndex = mask.style.zIndex + 1;
            }
            // 检测遮盖面板布局的函数
            var checkMaskSizeFunc = function () {
                if (mask.style.display != "none") {
                    var left2 = DCBrowserCompabitility.GetViewLeftInDocument(rootElement);
                    var top2 = DCBrowserCompabitility.GetViewTopInDocument(rootElement);
                    var modified = false;
                    if (mask.style.left != left2 + "px") {
                        mask.style.left = left2 + "px";
                        modified = true;
                    }
                    if (mask.style.top != top2 + "px") {
                        mask.style.top = top2 + "px";
                        modified = true;
                    }
                    if (mask.style.width != rootElement.offsetWidth + "px") {
                        mask.style.width = rootElement.offsetWidth + "px";
                        modified = true;
                    }
                    if (mask.style.height != rootElement.offsetHeight + "px") {
                        mask.style.height = rootElement.offsetHeight + "px";
                        modified = true;
                    }
                    if (modified == true) {
                        var ce = mask.currentContentElement;
                        if (ce != null && ce.style.display != "none") {
                            var v = mask.offsetLeft + (mask.offsetWidth - ce.offsetWidth) / 2;
                            ce.style.left = v + "px";
                            v = mask.offsetTop + (mask.offsetHeight - ce.offsetHeight) / 2;
                            ce.style.top = v + "px";
                        }
                    }
                    window.setTimeout(checkMaskSizeFunc, 400);
                }
            };
            window.setTimeout(checkMaskSizeFunc, 400);
            if (contentElement.focus) {
                contentElement.focus();
            }
            if (contentElement.setActive) {
                try {
                    contentElement.setActive();
                }
                catch (err) {
                }
            }
            return true;
        }
        return false;
    };

    // 隐藏控件的遮盖面板 *********************************************************************
    rootElement.hiddenMaskPanel = function () {
        var lbl = document.getElementById(this.id + "_ControlMask");
        if (lbl != null) {
            lbl.style.display = "none";
        }
    };
    // 显示操作等待界面 ***********************************************************************
    rootElement.ShowAppProcessing = function () {
        rootElement.showMaskPanel(document.getElementById(this.id + "_Processing"));
    };
    // 隐藏操作等待界面 ***********************************************************************
    rootElement.HiddenAppProcessing = function () {
        rootElement.hiddenMaskPanel();
        var lbl2 = document.getElementById(this.id + "_Processing");
        if (lbl2 != null) {
            lbl2.style.display = "none";
        }
    };

    rootElement.GetDialogContentFrameElement = function () {
        return document.getElementById(this.id + "_DialogContent");
    };

    // 显示遮盖对话框
    rootElement.ShowMaskDialog = function (clientWidth, clientHeight, title) {
        if (title == null || title.length == 0) {
            title = rootElement.GetDCWriterString("JS_Dialog");
        }
        // 设置标题
        var titleBox = document.getElementById(this.id + "_DialogTitle");
        while (titleBox.firstChild != null) {
            titleBox.removeChild(titleBox.firstChild);
        }
        titleBox.appendChild(document.createTextNode(title));
        var dlg = document.getElementById(this.id + "_Dialog");
        var frame = this.GetDialogContentFrameElement();
        if (clientWidth != null) {
            dlg.style.width = (clientWidth + 6) + "px";
            frame.style.width = clientWidth + "px";
        }
        if (clientHeight != null) {
            dlg.style.height = (clientHeight + 22) + "px";
            frame.style.height = clientHeight + "px";
        }
        rootElement.showMaskPanel(dlg);
        return frame;
    };

    // 关闭遮盖对话框 ************************************************************************
    rootElement.CloseMaskDialog = function () {
        var box = document.getElementById(this.id + "_Dialog");
        rootElement.hiddenMaskPanel();
        var box = document.getElementById(this.id + "_Dialog");
        if (box != null) {
            box.style.display = "none";
        }
        var frame = this.GetDialogContentFrameElement();
        if (frame != null) {
            frame.src = "about:blank";
        }
    }


    // 开始执行上传图片操作 *******************************************************************
    rootElement.EditUploadImage = function () {
        var frame = document.getElementById(this.id + "_Dialog");
        if (frame != null) {
            if (rootElement.showMaskPanel(frame)) {
                var func = function () {
                    rootElement.hiddenMaskPanel();
                    frame.style.display = "none";
                };
                rootElement.frameWindow.DCFileUploadManager.BeginUploadImage(this.GetDialogContentFrameElement(), func);
            }
        }
    };

    // 检查是否正在显示对话框
    rootElement.checkShowingDialog = function () {
        if (this.isShowingDialog()) {
            alert(rootElement.GetDCWriterString("JS_PromptShowingDialog"));
            return false;
        }
        return true;
    }

    // 判断是否正在显示对话框
    rootElement.isShowingDialog = function () {
        var lbl = document.getElementById(this.id + "_ControlMask");
        if (lbl != null && lbl.style.display != "none") {
            return true;
        }
        return false;
    }

    //debugger;
    // 加载字符串资源
    DCBrowserCompabitility.LoadJsonByUrl(
        "DCWriterStringsContainer",
        rootElement.getAttribute("servicepageurl") + "?dcwritergetstringresources=1");
    if (typeof (DCWriterStringsContainer) == "undefined") {
        DCWriterStringsContainer = {
            JS_PromptShowingDialog: "系统正在显示对话框，在关闭对话框前无法执行本操作。",
            JS_OK: "确定",
            JS_Cancel: "取消",
            JS_Dialog: "对话框"
        };
    }
    rootElement.DCWriterStringsContainer = DCWriterStringsContainer;

    // 获得指定名称的字符串资源
    rootElement.GetDCWriterString = function (name, parameters) {
        if (rootElement.DCWriterStringsContainer != null) {
            var text = rootElement.DCWriterStringsContainer[name];
            for (var iCount = 1; iCount < arguments.length; iCount++) {
                var v = arguments[iCount];
                var strV = "";
                if (typeof (v) != "undefined" && v != null) {
                    strV = v.toString();
                }
                text = text.replace("{" + (iCount - 1) + "}", strV);
            }
            return text;
        }
        return name;
    };

    //获得编辑器的XMLText 张昊 2017-2-15 EMREDGE-28
    rootElement.GetXmlContent = function () {
        return rootElement.frameWindow.WriterCommandModuleFile.GetXmlContent();
    };

    //    // 获得指定名称的字符串资源
    //    rootElement.frameWindow.GetDCWriterString = function (name, parameters) {
    //        if (rootElement.DCWriterStringsContainer != null) {
    //            var text = rootElement.DCWriterStringsContainer[name];
    //            for (var iCount = 1; iCount < arguments.length; iCount++) {
    //                var v = arguments[iCount];
    //                var strV = "";
    //                if (typeof (v) != "undefined" && v != null) {
    //                    strV = v.toString();
    //                }
    //                text = text.replace("{" + (iCount - 1) + "}", strV);
    //            }
    //            return text;
    //        }
    //        return name;
    //    };

    return true;
};
               
        

       
         

//------------------------------XReportWebControl ----------------------------------


//alert("bbbbbbbbbbbb");