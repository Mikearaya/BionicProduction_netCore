import { Component, OnInit } from '@angular/core';
import { AuthrizationService } from '../Modules/authorization/authrization.service';

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.css']
})
export class EntryComponent implements OnInit {
  logOutAlign = 'Right';
  constructor(private authrizationService: AuthrizationService) { }

  ngOnInit() {
  }

  isLogedIn(): boolean {
    return this.authrizationService.isLoggedIn();
  }
  logOut(): void {
    this.authrizationService.logout();
  }
}
