import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invoice-main',
  templateUrl: './invoice-main.component.html',
  styleUrls: ['./invoice-main.component.scss']
})
export class InvoiceMainComponent implements OnInit {

  sideBarOpen: boolean = true;
  constructor() { }

  ngOnInit(): void {
  }
  public sideBarToggler() {
    this.sideBarOpen = !this.sideBarOpen;
   }

}
