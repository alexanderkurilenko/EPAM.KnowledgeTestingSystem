var p = $("#stat  #avproc").text();
var t = $("#stat  #avtime").text();
p = p.replace('%', ' ');
t = t.replace(':', ' ');
var x = +p;

Morris.Donut({
    element: 'donut-chart',
    data: [
      { label: "Average Percent of true answers:", value: x},
      { label: "Average time:", value: +t },
    ]
});