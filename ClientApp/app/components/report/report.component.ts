import { Component, Inject, Input } from '@angular/core';
import { MaltidReportsComponent } from '../reports/maltidreports.component';

@Component({
    selector: 'report',
    templateUrl: './report.component.html',
})

export class ReportComponent {

    rapport_ID: number;
    portionstyp_ID: string;
    antal: number;
    verksamhet_ID: string;
    rapport_Anvandare: string;
    rapport_Datum: Date;

    @Input() reports: MaltidReportsComponent;

    constructor() {
    }
}

