import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {
  public legendSettings: Object;
  @Input('chartId') chartId: string;
  @Input('chartData') chartData: Object[];
  @Input('xAxis') xAxis: string;
  @Input('yAxis') yAxis: string;
  @Input('chartType') chartType: string;
  public datalabel: { visible: boolean; name: string; position: string; };



  ngOnInit(): void {
    this.datalabel = { visible: true, name: 'text', position: 'Outside' };
      this.chartData = [
              { x: 'Jan', y: 3, text: 'Jan: 3' }, { x: 'Feb', y: 3.5, text: 'Feb: 3.5' },
              { x: 'Mar', y: 7, text: 'Mar: 7' }, { x: 'Apr', y: 13.5, text: 'Apr: 13.5' },
              { x: 'May', y: 19, text: 'May: 19' }, { x: 'Jun', y: 23.5, text: 'Jun: 23.5' },
              { x: 'Jul', y: 26, text: 'Jul: 26' }, { x: 'Aug', y: 25, text: 'Aug: 25' },
              { x: 'Sep', y: 21, text: 'Sep: 21' }, { x: 'Oct', y: 15, text: 'Oct: 15' },
              { x: 'Nov', y: 9, text: 'Nov: 9' }, { x: 'Dec', y: 3.5, text: 'Dec: 3.5' }];

      this.legendSettings = {
          visible: false
      };
  }

}
