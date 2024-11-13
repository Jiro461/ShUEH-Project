import {
    DataGrid,
    GridColDef,
    GridToolbar,
  } from "@mui/x-data-grid";
  import "./dataTable.scss";
  import { Box, useMediaQuery } from '@mui/material';
  import { Link } from "react-router-dom";
  import Update from "../update/Update";
import * as adminProductsService from "../../../services/adminProductsService"
import * as adminUsersService from "../../../services/adminUsersService"
import * as adminOrdersService from "../../../services/adminOrdersService"
import * as adminDiscountsService from "../../../services/adminDiscountsService"
import { useState } from "react";

  const DataTable = (props) => {
    const [open, setOpen] = useState(false)
    const [id, setId] = useState()
    const isSmallScreen = useMediaQuery('(max-width:600px)');

    const handleUpdate = async (id) => {
      setOpen(true)
      setId(id)
    }

    const handleDelete = async (id) => {
        props.setOpenBackDrop(true)
        let res = {}
        if (props.slug === "products"){
          res = await adminProductsService.deleteProduct(id)
        }
        if (props.slug === "users"){
          res = await adminUsersService.deleteUser(id)
        }
        if (props.slug === "orders"){
          res = await adminOrdersService.deleteOrder(id)
        }
        if (props.slug === "discounts"){
          res = await adminDiscountsService.deleteDiscount(id)
        }
        await props.fetchData()
        props.setOpenToastMessage(true)
        props.setTypeToastMessage(res.type)
        props.setTitleToastMessage(res.message)
        props.setOpenBackDrop(false)
 
    };
  
    const actionColumn = {
      field: "action",
      headerName: "Action",
      width: 100,
      renderCell: (params) => {
        return (
          <div className="action">
            {(props.slug === "products" || props.slug === "users") 
            && <Link to={`/admin/${props.slug}/${params.row.id}`}>
              <img src="/view.svg" alt="" />
            </Link>}
            <div className="update" onClick={() => handleUpdate(params.row.id)}>
              <i className="fa-solid fa-wrench" style={{color: "#74C0FC", cursor: "pointer"}}></i>
            </div>
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
                pageSize: 5,
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
        {open && <Update 
        slug={props.updateSlug} 
        setOpen={setOpen} 
        inputs={props.inputs} 
        fetchData={props.fetchData}
        setOpenBackDrop={props.setOpenBackDrop}
        setOpenToastMessage={props.setOpenToastMessage}
        setTypeToastMessage={props.setTypeToastMessage}
        setTitleToastMessage={props.setTitleToastMessage} 
        id={id} ></Update>}
      </div>    
    );
  }
  
  
  export default DataTable;