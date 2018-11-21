import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-stat-card',
  templateUrl: './stat-card.component.html',
  styleUrls: ['./stat-card.component.css']
})
export class StatCardComponent implements OnInit {

@Input('prefix') prefix: string;
@Input('postfix') postfix: string;
@Input('title') title: string;
@Input('data') data: any;
  constructor() { }

  ngOnInit() {
  }

}
