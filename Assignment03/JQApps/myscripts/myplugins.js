(function ($) {
    $.fn.drawBox = function (options) {
        var settings = $.extend({  // define defaults for parameters
            color: "red",
            backgroundColor: "white"
        }, options);
        this.filter("p,div").each(function () {
            var para = $(this);
            countchars = para.text().length;
            para.css({
                'color': settings.color, 'background-color': settings.backgroundColor,
                'border': '1px solid red', 'font-size': '12pt', 'width': countchars * 7
            });
        });
        return this;   // so that it can be chained later
    };
}(jQuery));

(function ($) {
    $.fn.bootTable = function (options) {
        var settings = $.extend({  // define defaults for parameters
            width: "60%",
            alternatingRowColor: "#ddffdd"
        }, options);
        this.filter("table").each(function () {
            var table = $(this);
            table.attr("class", "table table-striped table-bordered table-condensed");
            table.attr("align", "center");
            table.css({ "text-align": "center","width":settings.width});
            $(this).find("tr:even").css({ 'background-color': settings.alternatingRowColor });
            table.find("th").css({ 'padding': '3px' });
            table.find("td").css({ 'padding': '2px' });
        });
        return this;   // so that it can be chained later
    };
}(jQuery));