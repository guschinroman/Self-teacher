"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var ListDto = /** @class */ (function (_super) {
    __extends(ListDto, _super);
    function ListDto() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.Result = undefined;
        _this.CurrentPage = undefined;
        _this.PageCount = undefined;
        _this.PageSize = undefined;
        _this.RowCount = undefined;
        _this.FirstRowOnPage = undefined;
        _this.LastRowOnPage = undefined;
        return _this;
    }
    return ListDto;
}(Array));
exports.ListDto = ListDto;
//# sourceMappingURL=ListDto.js.map