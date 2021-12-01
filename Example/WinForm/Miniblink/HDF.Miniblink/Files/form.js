
if (window[dragName]) {
    var dragFunc = window[dragName];
    document.getElementsByTagName("body")[0].addEventListener("mousedown",
        function (e) {
            var obj = e.target || e.srcElement;
            if ({ "INPUT": 1, "SELECT": 1 }[obj.tagName.toUpperCase()])
                return;

            while (obj) {
                for (var i = 0; i < obj.classList.length; i++) {
                    if (obj.classList[i] === "mbform-nodrag")
                        return;
                    if (obj.classList[i] === "mbform-drag") {
                        dragFunc();
                        return;
                    }
                }
                obj = obj.parentElement;
            }
        });
}

if (window[maxName]) {
    var maxFunc = window[maxName];
    var els = document.getElementsByClassName("mbform-max");
    for (var i = 0; i < els.length; i++) {
        els[i].addEventListener("click", function() { maxFunc(); });
    }
}

if (window[minName]) {
    var minFunc = window[minName];
    var els = document.getElementsByClassName("mbform-min");
    for (var i = 0; i < els.length; i++) {
        els[i].addEventListener("click", function () { minFunc(); });
    }
}

if (window[closeName]) {
    var closeFunc = window[closeName];
    var els = document.getElementsByClassName("mbform-close");
    for (var i = 0; i < els.length; i++) {
        els[i].addEventListener("click", function () { closeFunc(); });
    }
}