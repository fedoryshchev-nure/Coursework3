import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { QueryService } from 'app/walls-state/services/query.service';

@Component({
  selector: 'app-automat',
  templateUrl: './automat.component.html',
  styleUrls: ['./automat.component.css']
})
export class AutomatComponent implements OnInit {
  regions$: Observable<string[]>;
  materials$: Observable<string[]>;

  regions = true;
  materials = false;
  
  constructor(
    private queryService: QueryService
  ) { }

  ngOnInit() {
    this.regions$ = this.queryService
      .GetBestRegions();
    this.materials$ = this.queryService
      .GetBestMaterials();
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
