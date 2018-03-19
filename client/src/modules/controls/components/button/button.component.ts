import { Component, Input } from "@angular/core";

@Component({
    selector: 'r--button',
    templateUrl: './button.template.html',
    styleUrls: [ './button.style.scss' ]
})
export class ButtonComponent { 

    private _primary: boolean;
    @Input('primary')
    public get Primary() { return this._primary; }
    public set Primary(value: any) { this._primary = value != null && `${value}` !== 'false'; }

}