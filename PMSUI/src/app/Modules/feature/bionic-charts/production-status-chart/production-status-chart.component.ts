import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-production-status-chart',
  templateUrl: './production-status-chart.component.html',
  styleUrls: ['./production-status-chart.component.css']
})
export class ProductionStatusChartComponent implements OnInit {
  legendSettings: { visible: boolean; };
  piedata: { x: string; y: number; text: string; }[];
  datalabel: { visible: boolean; name: string; position: string; };
  public map: Object = 'fill';
  constructor() { }

  ngOnInit() {
    this.piedata = [
      { x: 'Jan', y: 3, text: 'Jan: 3' }, { x: 'Feb', y: 3.5, text: 'Feb: 3.5' },
      { x: 'Mar', y: 7, text: 'Mar: 7' }, { x: 'Apr', y: 13.5, text: 'Apr: 13.5' },
      { x: 'May', y: 19, text: 'May: 19' }, { x: 'Jun', y: 23.5, text: 'Jun: 23.5' },
      { x: 'Jul', y: 26, text: 'Jul: 26' }, { x: 'Aug', y: 25, text: 'Aug: 25' },
      { x: 'Sep', y: 21, text: 'Sep: 21' }, { x: 'Oct', y: 15, text: 'Oct: 15' },
      { x: 'Nov', y: 9, text: 'Nov: 9' }, { x: 'Dec', y: 3.5, text: 'Dec: 3.5' }];
      this.datalabel = { visible: true, name: 'text', position: 'Outside' };
    this.legendSettings = {
      visible: false
    };

    this.datalabel = { visible: true, name: 'text', position: 'Outside' };
  }

}
