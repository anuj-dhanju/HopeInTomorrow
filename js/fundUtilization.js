require([
    "dojo/_base/declare",
    "dojox/charting/Chart",
    "dojox/charting/plot2d/Pie",
    "dojox/charting/themes/Claro",
    "dojox/charting/action2d/MoveSlice"], function (declare, Chart, Pie, theme, MoveSlice) {

    var Donut = declare(Pie, {
        render: function (dim, offsets) {
            // Call the Pie's render method
            this.inherited(arguments);

            // Draw a white circle in the middle
            var rx = (dim.width - offsets.l - offsets.r) / 2,
                ry = (dim.height - offsets.t - offsets.b) / 2,
                r = Math.min(rx, ry) / 2;
            var circle = {
                cx: offsets.l + rx,
                cy: offsets.t + ry,
                r: r
            };
            var s = this.group;

            s.createCircle(circle).setFill("#fff").setStroke("#fff");
        }
    });

    // Create the chart within it's "holding" node
    var pieChart = new Chart("chartNode"),
        chartData = [{
            x: 1,
            y: 19021
        }, {
            x: 1,
            y: 14455
        }, {
            x: 1,
            y: 12378
        }, {
            x: 1,
            y: 21882
        }];

    // Set the theme
    pieChart.setTheme(theme);

    // Add the only/default plot
    pieChart.addPlot("default", {
        type: Donut, // our plot2d/Pie module reference as type value
        radius: 200,
        fontColor: "black",
        labelOffset: -20
    });

    // Add the series of data
    pieChart.addSeries("January", chartData);

    // Animate the donut slices
    new MoveSlice(pieChart, "default");
    // Render the chart!
    pieChart.render();

    });
