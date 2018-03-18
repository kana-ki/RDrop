import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app-root.template.html',
  styleUrls: [ './app-root.style.scss' ]
})
export class AppComponent {
  
  private Title : String 
  
  constructor() {
    this.Title = "RDrop";
  }

}