import { EventEmitter } from '@angular/core';
import { DragDropConfig } from './dnd.config';
export declare class DragDropData {
    dragData: any;
    mouseEvent: MouseEvent;
}
export declare function dragDropServiceFactory(): DragDropService;
export declare class DragDropService {
    allowedDropZones: Array<string>;
    onDragSuccessCallback: EventEmitter<DragDropData>;
    dragData: any;
    isDragged: boolean;
}
export declare function dragDropSortableServiceFactory(config: DragDropConfig): DragDropSortableService;
export declare class DragDropSortableService {
    private _config;
    index: number;
    sortableData: Array<any>;
    isDragged: boolean;
    private _elem;
    readonly elem: HTMLElement;
    constructor(_config: DragDropConfig);
    markSortable(elem: HTMLElement): void;
}
