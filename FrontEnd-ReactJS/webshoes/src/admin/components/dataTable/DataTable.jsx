import {
    DataGrid,
    GridColDef,
    GridToolbar,
  } from "@mui/x-data-grid";
  import "./dataTable.scss";
  import { Box, useMediaQuery } from '@mui/material';
  import { Link } from "react-router-dom";
  // import { useMutation, useQueryClient } from "@tanstack/react-query";
  

  const DataTable = (props) => {
    const isSmallScreen = useMediaQuery('(max-width:600px)');

    // TEST THE API
  
    // const queryClient = useQueryClient();
    // // const mutation = useMutation({
    // //   mutationFn: (id: number) => {
    // //     return fetch(`http://localhost:8800/api/${props.slug}/${id}`, {
    // //       method: "delete",
    // //     });
    // //   },
    // //   onSuccess: ()=>{
    // //     queryClient.invalidateQueries([`all${props.slug}`]);
    // //   }
    // // });
  
    const handleDelete = (id) => {
      //delete the item
      // mutation.mutate(id)
    };
  
    const actionColumn = {
      field: "action",
      headerName: "Action",
      width: 200,
      renderCell: (params) => {
        return (
          <div className="action">
            <Link to={`/${props.slug}/${params.row.id}`}>
              <img src="/view.svg" alt="" />
            </Link>
            <div className="delete" onClick={() => handleDelete(params.row.id)}>
              <img src="/delete.svg" alt="" />
            </div>
          </div>
        );
      },
    };
    return (    
      <div className="dataTable">
        <DataGrid
          className="dataGrid"
          rows={props.rows}
          style={{ maxWidth: '100%' }}
          sx={{
            width: "100%",
            maxWidth: "100%",
          }}
          columns={[...props.columns, actionColumn]}
          initialState={{
            pagination: {
              paginationModel: {
                pageSize: 10,
              },
            },
          }}
          slots={{ toolbar: GridToolbar }}
          slotProps={{
            toolbar: {
              showQuickFilter: true,
              quickFilterProps: { debounceMs: 500 },
            },
          }}
          pageSizeOptions={[5]}
          checkboxSelection
          autoWidth
          disableExtendRowFullWidth={true}
          disableRowSelectionOnClick
          disableColumnFilter
          disableDensitySelector
          disableColumnSelector
        />
      </div>    
    );
  }
  
  
  export default DataTable;