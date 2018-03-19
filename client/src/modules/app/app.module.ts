import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { DownloadsModule } from "../downloads/downloads.module";
import { AppComponent } from "./components/app-root/app-root.component";
import { AppTitleComponent } from "./components/app-title/app-title.component";

@NgModule({
    declarations: [ AppComponent, AppTitleComponent ],
    imports: [ BrowserModule, DownloadsModule ],
    bootstrap: [ AppComponent, AppTitleComponent ]
  })
export class AppModule { }