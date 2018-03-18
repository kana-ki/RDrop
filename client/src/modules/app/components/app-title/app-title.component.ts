import { Component } from "@angular/core";

@Component({
    selector: '[app-title]',
    template: '{{ Title }}'
})
export class AppTitleComponent {

    public Title : string = "RDrop - Dashboard"

}
