// 子文档元素对象处理器

var DCSubDocumentManager = new Object();

// 获得文档中所有的子文档元素对象
DCSubDocumentManager.getSubDocuments = function () {
    var result = new Array();
    var allDiv = document.getElementsByTagName("DIV");
    for (var iCount = 0; iCount < allDiv.length; iCount++) {
        var node = allDiv[iCount];
        if (node.getAttribute("dctype") == "XTextSubDocumentElement") {
            if (node.select == null) {
                node.select = function () {
                    DCWriterControllerEditor.SetFocus(this);
                    DCDomTools.selectContent(
                        this,
                        0,
                        this,
                        this.childNodes.length
                        );
                    if (this.scrollIntoView) {
                        this.scrollIntoView();
                    }
                }
            }
            result.push(node);
        }
    } //for
    return result;
}