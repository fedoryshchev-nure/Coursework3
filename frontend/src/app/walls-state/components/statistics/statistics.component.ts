import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { QueryService } from 'app/walls-state/services/query.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  regions$: Observable<string[]>;
  materials$: Observable<string[]>;

  regions = true;
  materials = false;

  constructor(
    private queryService: QueryService
  ) { }

  ngOnInit() {
    this.regions$ = this.queryService
      .GetRegionsOrderedByWallDamage();
    this.materials$ = this.queryService
      .GetMostDamagedMaterials();
  }

  onRegionsClick(): void {
    this.regions = true;
    this.materials = false;
  }

  onMaterialsClick(): void {
    this.regions = false;
    this.materials = true;
  }

}
