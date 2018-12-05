import { Component, OnInit } from '@angular/core';

import { StateService } from 'app/walls-state/services/state.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  wallsFine = false;
  wallsNotFine = false;

  errorOccurd = false;

  constructor(
    private stateService: StateService
  ) { }

  ngOnInit() {
  }

  getState(): void {
    this.stateService.getState().subscribe(state => {
      if (state) {
        this.wallsFine = true;
        this.wallsNotFine = false;
      } else {
        this.wallsFine = false;
        this.wallsNotFine = true;
      }
    }, error => {
      this.errorOccurd = true;
    });
  }
}
