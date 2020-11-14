import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-thumbnail',
  templateUrl: './thumbnail.component.html',
  styleUrls: ['./thumbnail.component.css']
})
export class ThumbnailComponent implements OnInit {

    @Input() // חשיפת המשתנה מהרכיב החוצה
    public imageSource: string;

    @Input("w") // חשיפת המשתנה החוצה ע"י שם שונה
    public imageWidth: number;

    @Input("h") // חשיפת המשתנה החוצה ע"י שם שונה
    public imageHeight: number;

    @Input()
    public imageTitle: string;

    constructor() { }

    ngOnInit() {
    }

}
