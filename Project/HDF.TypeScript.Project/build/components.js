"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Footer = exports.Content = exports.Header = void 0;
var Header = /** @class */ (function () {
    function Header() {
        var div = document.createElement('div');
        div.innerText = 'this is header';
        document.body.appendChild(div);
    }
    return Header;
}());
exports.Header = Header;
var Content = /** @class */ (function () {
    function Content() {
        var div = document.createElement('div');
        div.innerText = 'this is content';
        document.body.appendChild(div);
    }
    return Content;
}());
exports.Content = Content;
var Footer = /** @class */ (function () {
    function Footer() {
        var div = document.createElement('div');
        div.innerText = 'this is footer';
        document.body.appendChild(div);
    }
    return Footer;
}());
exports.Footer = Footer;
