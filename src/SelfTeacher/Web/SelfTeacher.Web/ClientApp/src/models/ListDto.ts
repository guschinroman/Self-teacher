


export class ListDto <T> extends Array<any> {
	public Result?: T[] = undefined;
	public CurrentPage?: number = undefined;
	public PageCount?: number = undefined;
	public PageSize?: number = undefined;
	public RowCount?: number = undefined;
	public FirstRowOnPage?: number = undefined;
	public LastRowOnPage?: number = undefined;
}
 
