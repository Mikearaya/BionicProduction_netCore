import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-logger',
  template: `
    <p>
      logger works!
    </p>
  `,
  styles: []
})
export class LoggerComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
