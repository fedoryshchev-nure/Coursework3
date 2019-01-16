import { Component, OnInit } from '@angular/core';

import { QueryService } from 'app/walls-state/services/query.service';
import { Observable } from 'rxjs';
import { WallDTO } from 'app/walls-state/dtos/wall-dto';

@Component({
  selector: 'app-walls-data',
  templateUrl: './walls-data.component.html',
  styleUrls: ['./walls-data.component.css']
})
export class WallsDataComponent implements OnInit {
  wallDTOs$: Observable<WallDTO[]>;
  errorOccurd = false;

  showBroken = true;
  showMaterial = false;

  constructor(
    private queryService: QueryService
  ) { }

  ngOnInit() {
    this.wallDTOs$ = this.queryService
      .GetWallsWithSensorForUser();
  }

  onShowMaterialClick(): void {
    this.showBroken = false;
    this.showMaterial = true;
  }

  onShowBrokenClick(): void {
    this.showBroken = true;
    this.showMaterial = false;

  }

}
