import { Component, Inject } from '@angular/core';

@Component({
    selector: 'report-date',
    templateUrl: './reportdate.component.html',
})

export class ReportDateComponent {

    public curr: string;

    today: Date;

    constructor() {
        this.today = new Date();
        console.log(this.today.toISOString());
        this.curr = this.today.toISOString();
    }
}

