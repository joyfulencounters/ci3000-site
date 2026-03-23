var CANVAS_WIDTH = 284;
var CANVAS_HEIGHT = 266;
var ICON_SIZE = 92;
var LEFT_EDGE = (CANVAS_WIDTH - ICON_SIZE) / 2;
var TOP_EDGE = (CANVAS_HEIGHT - ICON_SIZE) / 2;

(function ($) {
    function initAvatarCrop() {
        var $iconElement = $("#ImageIcon");
        var $imageDrag = $("#ImageDrag");

        if ($iconElement.length === 0 || $imageDrag.length === 0) {
            return;
        }

        var imageSrc = $iconElement.attr("src");
        if (!imageSrc) {
            return;
        }

        var image = new Image();
        image.onload = function () {
            var realWidth = image.width;
            var realHeight = image.height;

            if (!realWidth || !realHeight) {
                return;
            }

            var minFactor = ICON_SIZE / Math.max(realWidth, realHeight);
            if (ICON_SIZE > realWidth && ICON_SIZE > realHeight) {
                minFactor = 1;
            }

            var factor = minFactor > 0.25 ? 8.0 : 4.0 / Math.sqrt(minFactor);

            var scaleFactor = 1;
            if (realWidth > CANVAS_WIDTH && realHeight > CANVAS_HEIGHT) {
                if (realWidth / CANVAS_WIDTH > realHeight / CANVAS_HEIGHT) {
                    scaleFactor = CANVAS_HEIGHT / realHeight;
                } else {
                    scaleFactor = CANVAS_WIDTH / realWidth;
                }
            }

            var sliderLeft = 100 * (Math.log(scaleFactor * factor) / Math.log(factor));
            $(".child").css("left", sliderLeft + "px");

            var currentWidth = Math.round(scaleFactor * realWidth);
            var currentHeight = Math.round(scaleFactor * realHeight);

            var originLeft = Math.round((CANVAS_WIDTH - currentWidth) / 2);
            var originTop = Math.round((CANVAS_HEIGHT - currentHeight) / 2);

            var dragLeft = originLeft - LEFT_EDGE;
            var dragTop = originTop - TOP_EDGE;

            $iconElement.css({
                width: currentWidth + "px",
                height: currentHeight + "px",
                left: originLeft + "px",
                top: originTop + "px"
            });

            $imageDrag.css({
                width: currentWidth + "px",
                height: currentHeight + "px",
                left: dragLeft + "px",
                top: dragTop + "px"
            });

            $("#txt_width").val(currentWidth);
            $("#txt_height").val(currentHeight);
            $("#txt_top").val(0 - dragTop);
            $("#txt_left").val(0 - dragLeft);
            $("#txt_Zoom").val(scaleFactor);

            var oldWidth = currentWidth;
            var oldHeight = currentHeight;

            if ($imageDrag.data("draggable")) {
                $imageDrag.draggable("destroy");
            }
            if ($iconElement.data("draggable")) {
                $iconElement.draggable("destroy");
            }
            if ($(".child").data("draggable")) {
                $(".child").draggable("destroy");
            }

            $imageDrag.draggable({
                cursor: "move",
                drag: function () {
                    var pos = $imageDrag.position();

                    $iconElement.css({
                        left: (parseInt(pos.left, 10) + LEFT_EDGE) + "px",
                        top: (parseInt(pos.top, 10) + TOP_EDGE) + "px"
                    });

                    $("#txt_left").val(0 - parseInt(pos.left, 10));
                    $("#txt_top").val(0 - parseInt(pos.top, 10));
                }
            });

            $iconElement.draggable({
                cursor: "move",
                drag: function () {
                    var pos = $iconElement.position();

                    $imageDrag.css({
                        left: (parseInt(pos.left, 10) - LEFT_EDGE) + "px",
                        top: (parseInt(pos.top, 10) - TOP_EDGE) + "px"
                    });

                    $("#txt_left").val(0 - (parseInt(pos.left, 10) - LEFT_EDGE));
                    $("#txt_top").val(0 - (parseInt(pos.top, 10) - TOP_EDGE));
                }
            });

            function applyScaleBySlider(left) {
                if (left < 0) left = 0;
                if (left > 200) left = 200;

                scaleFactor = Math.pow(factor, (left / 100 - 1));
                if (scaleFactor < minFactor) scaleFactor = minFactor;
                if (scaleFactor > factor) scaleFactor = factor;

                var currentWidth = Math.round(scaleFactor * realWidth);
                var currentHeight = Math.round(scaleFactor * realHeight);

                var originLeft = parseInt($iconElement.css("left"), 10);
                var originTop = parseInt($iconElement.css("top"), 10);

                originLeft -= Math.round((currentWidth - oldWidth) / 2);
                originTop -= Math.round((currentHeight - oldHeight) / 2);

                var dragLeft = originLeft - LEFT_EDGE;
                var dragTop = originTop - TOP_EDGE;

                $(".child").css("left", left + "px");

                $iconElement.css({
                    width: currentWidth + "px",
                    height: currentHeight + "px",
                    left: originLeft + "px",
                    top: originTop + "px"
                });

                $imageDrag.css({
                    width: currentWidth + "px",
                    height: currentHeight + "px",
                    left: dragLeft + "px",
                    top: dragTop + "px"
                });

                $("#txt_Zoom").val(scaleFactor);
                $("#txt_left").val(0 - dragLeft);
                $("#txt_top").val(0 - dragTop);
                $("#txt_width").val(currentWidth);
                $("#txt_height").val(currentHeight);

                oldWidth = currentWidth;
                oldHeight = currentHeight;
            }

            $(".child").draggable({
                cursor: "move",
                containment: $("#bar"),
                drag: function () {
                    var left = parseInt($(this).css("left"), 10);
                    applyScaleBySlider(left);
                }
            });

            $("#moresmall").off("click").on("click", function (e) {
                e.preventDefault();
                var left = parseInt($(".child").css("left"), 10) || 0;
                applyScaleBySlider(left - 20);
            });

            $("#morebig").off("click").on("click", function (e) {
                e.preventDefault();
                var left = parseInt($(".child").css("left"), 10) || 0;
                applyScaleBySlider(left + 20);
            });
        };

        image.src = imageSrc;
    }

    $(function () {
        initAvatarCrop();
    });

    window.initAvatarCrop = initAvatarCrop;
})(jQuery);