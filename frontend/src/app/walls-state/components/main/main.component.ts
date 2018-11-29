import { Component, OnInit } from '@angular/core';

import { StateService } from 'app/walls-state/services/state.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  successMessages: string[] = [];
  errorMessages: string[] = [];

  constructor(
    private stateService: StateService
  ) { }

  ngOnInit() {
  }

  getState(): void {
    this.stateService.getState().subscribe(state => {
      if (state) {
        this.successMessages = ['Walls are fine'];
      }
      else {
        this.errorMessages = ['Walls are not fine'];
      }
    }, error => {
      this.errorMessages = [error.error];
    });
  }
}
