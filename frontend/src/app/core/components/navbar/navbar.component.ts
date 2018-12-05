import { Component, OnInit } from '@angular/core';

import { TranslateService } from '@ngx-translate/core';

import { AuthService } from 'app/core/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(
    public authService: AuthService,
    public translate: TranslateService
  ) { }

  ngOnInit() {
  }

  public onButtonGroupClick($event){
    let clickedElement = $event.target || $event.srcElement;

    if( clickedElement.nodeName === "BUTTON" ) {
      let isCertainButtonAlreadyActive = 
        clickedElement
        .parentElement
        .querySelector(".active");
     
      if( isCertainButtonAlreadyActive ) {
        isCertainButtonAlreadyActive
          .classList
          .remove("active");
      }

      clickedElement.className += " active";
    }
  }
}
