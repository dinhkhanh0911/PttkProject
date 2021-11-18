

    
   
    function tinhchange(res) {
        let id = res.value;
        let slHuyen = $("#huyenID");
        slHuyen.empty();
        slHuyen.append(`<option>Huyện</option>`);
        huyen.map((val) => {
            if(val.tinhID==id)slHuyen.append(`<option value="${val.ID}">${val["tenHuyen"]}</option>`);
        })

    }
    function huyenchange(res) {
        let id = res.value;
        let slxa = $("#xaID");
        slxa.empty();
        slxa.append(`<option>Xã</option>`);
        xa.map((val) => {
            if (val.huyenID == id) slxa.append(`<option value="${val.ID}">${val["tenXa"]}</option>`);
        })
    }
    function loadDC() {
        let slTinh = $("#tinhID");
        let slHuyen = $("#huyenID");
        let slXa = $("#xaID");
        slTinh.empty();
        slTinh.append(`<option>Tỉnh</option>`);
        for (let temp of tinh) {
            slTinh.append(`<option value="${temp["ID"]}">${temp["tenTinh"]}</option>`);
        }        
    };
    loadDC();
