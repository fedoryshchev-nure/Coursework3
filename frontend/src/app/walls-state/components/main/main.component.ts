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
    this.stateService.
  }
}
