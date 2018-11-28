import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  public isSignedIn(): boolean {
    return !!sessionStorage.getItem('jwt');
  }

  public signOut(): void {
    sessionStorage.removeItem('jwt');
  }
}
